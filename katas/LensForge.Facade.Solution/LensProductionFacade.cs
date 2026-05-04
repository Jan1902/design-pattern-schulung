using LensForge.Facade;
using LensForge.Shared;

namespace LensForge.Facade.Solution;

public class LensProductionFacade
{
    private readonly LensGrinder _grinder;
    private readonly CoatingStation _coater;
    private readonly BasicQaInspector _inspector;
    private readonly PackagingFactory _packagingFactory;
    private readonly Shipper _shipper;
    private readonly AuditLogger _audit;
    private readonly InventoryService _inventory;

    public LensProductionFacade(
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

    public ShipmentReceipt? ProduceAndShip(Lens lens, CustomerType customer, string source)
    {
        _audit.LogProductionStart(lens, source);
        _inventory.ReserveLensBlank(lens);

        _grinder.PowerOn();
        _grinder.WarmUp();
        var grindResult = _grinder.Grind(lens, targetDiameter: 52);
        if (!grindResult.Success)
            return Abort(lens);

        _coater.Calibrate();
        _coater.PreheatChamber();
        var coatingResult = _coater.ApplyCoating(grindResult.Lens, "anti-reflex", 80);
        _coater.CoolDown();
        if (!coatingResult.Success)
            return Abort(lens);

        var qaReport = _inspector.Inspect(coatingResult.Lens);
        if (!qaReport.Passed)
            return Abort(lens);

        _inventory.ConfirmConsumption(lens);

        var packaging = _packagingFactory.CreateFor(customer);
        packaging.PackLens(qaReport.Lens);

        _shipper.OpenGate();
        var receipt = _shipper.Ship(qaReport.Lens, packaging);
        _shipper.CloseGate();

        _audit.LogProductionEnd(lens, success: true);
        _grinder.PowerOff();

        return receipt;
    }

    private ShipmentReceipt? Abort(Lens lens)
    {
        _inventory.ReleaseReservation(lens);
        _audit.LogProductionEnd(lens, success: false);
        _grinder.PowerOff();
        return null;
    }
}