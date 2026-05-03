using LensForge.Shared;

namespace LensForge.Facade;

public class BatchProductionJob
{
    private readonly LensGrinder _grinder;
    private readonly CoatingStation _coater;
    private readonly BasicQaInspector _inspector;
    private readonly PackagingFactory _packagingFactory;
    private readonly Shipper _shipper;
    private readonly AuditLogger _audit;
    private readonly InventoryService _inventory;

    public BatchProductionJob(
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

    public void RunNightlyBatch(IEnumerable<(Lens lens, CustomerType customer)> orders)
    {
        // Subsysteme einmal vor dem Batch hochfahren (Performance)
        _grinder.PowerOn();
        _grinder.WarmUp();
        _coater.Calibrate();
        _coater.PreheatChamber();
        _shipper.OpenGate();

        foreach (var (lens, customer) in orders)
        {
            _audit.LogProductionStart(lens, "BatchJob");
            _inventory.ReserveLensBlank(lens);

            var grindResult = _grinder.Grind(lens, targetDiameter: 52);
            if (!grindResult.Success)
            {
                _inventory.ReleaseReservation(lens);
                _audit.LogProductionEnd(lens, success: false);
                continue;
            }

            var coatingResult = _coater.ApplyCoating(grindResult.Lens, "anti-reflex", 80);
            if (!coatingResult.Success)
            {
                _inventory.ReleaseReservation(lens);
                _audit.LogProductionEnd(lens, success: false);
                continue;
            }

            var qaReport = _inspector.Inspect(coatingResult.Lens);
            if (!qaReport.Passed)
            {
                _inventory.ReleaseReservation(lens);
                _audit.LogProductionEnd(lens, success: false);
                continue;
            }

            _inventory.ConfirmConsumption(lens);
            var packaging = _packagingFactory.CreateFor(customer);
            packaging.PackLens(qaReport.Lens);
            _shipper.Ship(qaReport.Lens, packaging);

            _audit.LogProductionEnd(lens, success: true);
        }

        _coater.CoolDown();
        _shipper.CloseGate();
        _grinder.PowerOff();
    }
}