using LensForge.Shared;

namespace LensForge.Facade;

public class LensGrinder
{
    public void PowerOn() { }
    public void WarmUp() { }
    public GrindResult Grind(Lens lens, int targetDiameter) => null!;
    public void PowerOff() { }
}

public class CoatingStation
{
    public void Calibrate() { }
    public void PreheatChamber() { }
    public CoatingResult ApplyCoating(Lens lens, string type, int intensity) => null!;
    public void CoolDown() { }
}

public class BasicQaInspector
{
    public QualityReport Inspect(Lens lens) => null!;
}

public class PackagingFactory
{
    public IPackaging CreateFor(CustomerType customerType) => null!;
}

public class Shipper
{
    public void OpenGate() { }
    public ShipmentReceipt Ship(Lens lens, IPackaging packaging) => null!;
    public void CloseGate() { }
}

public class AuditLogger
{
    public void LogProductionStart(Lens lens, string requestSource) { }
    public void LogProductionEnd(Lens lens, bool success) { }
}

public class InventoryService
{
    public void ReserveLensBlank(Lens lens) { }
    public void ConfirmConsumption(Lens lens) { }
    public void ReleaseReservation(Lens lens) { }
}

// =============================================================
//  Zusätzliche Domain-Typen
// =============================================================

public record GrindResult(Lens Lens, bool Success);
public record CoatingResult(Lens Lens, bool Success);
public record QualityReport(Lens Lens, bool Passed);
public record ShipmentReceipt(string TrackingNumber, DateTime ShippedAt);

public interface IPackaging
{
    void PackLens(Lens lens);
}