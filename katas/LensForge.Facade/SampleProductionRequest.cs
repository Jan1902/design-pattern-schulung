using LensForge.Shared;

namespace LensForge.Facade;

public class SampleProductionRequest
{
    private readonly LensGrinder _grinder;
    private readonly CoatingStation _coater;
    private readonly BasicQaInspector _inspector;
    private readonly PackagingFactory _packagingFactory;
    private readonly Shipper _shipper;
    private readonly AuditLogger _audit;
    private readonly InventoryService _inventory;

    public SampleProductionRequest(
        LensGrinder grinder,
        CoatingStation coater,
        BasicQaInspector inspector,
        PackagingFactory packagingFactory,
        Shipper shipper,
        AuditLogger audit,
        InventoryService inventory)
    {
        _grinder = grinder;
        _coater = coater;
        _inspector = inspector;
        _packagingFactory = packagingFactory;
        _shipper = shipper;
        _audit = audit;
        _inventory = inventory;
    }

    public ShipmentReceipt CreateSample(Lens lens, string salesContactAddress)
    {
        _audit.LogProductionStart(lens, "SalesSample");
        _inventory.ReserveLensBlank(lens);

        _grinder.PowerOn();
        _grinder.WarmUp();
        var grindResult = _grinder.Grind(lens, targetDiameter: 52);
        if (!grindResult.Success)
        {
            _inventory.ReleaseReservation(lens);
            _audit.LogProductionEnd(lens, success: false);
            return null!;
        }

        _coater.Calibrate();
        _coater.PreheatChamber();
        var coatingResult = _coater.ApplyCoating(grindResult.Lens, "anti-reflex", 80);
        _coater.CoolDown();
        if (!coatingResult.Success)
        {
            _inventory.ReleaseReservation(lens);
            _audit.LogProductionEnd(lens, success: false);
            return null!;
        }

        var qaReport = _inspector.Inspect(coatingResult.Lens);
        if (!qaReport.Passed)
        {
            _inventory.ReleaseReservation(lens);
            _audit.LogProductionEnd(lens, success: false);
            return null!;
        }

        _inventory.ConfirmConsumption(lens);

        // Muster gehen immer als Endkunden-Verpackung raus, unabhängig vom Kunden
        var packaging = _packagingFactory.CreateFor(CustomerType.EndCustomer);
        packaging.PackLens(qaReport.Lens);

        _shipper.OpenGate();
        var receipt = _shipper.Ship(qaReport.Lens, packaging);
        _shipper.CloseGate();

        _audit.LogProductionEnd(lens, success: true);
        _grinder.PowerOff();

        return receipt;
    }
}