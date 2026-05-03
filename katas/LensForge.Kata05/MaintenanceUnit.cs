namespace LensForge.Kata05;

public class MaintenanceUnit
{
    private readonly ProductionLogger _logger = new ProductionLogger();

    public void RunDiagnostics()
    {
        _logger.Info("Wartung", "Starte Diagnose-Lauf");
        Thread.Sleep(300);
        _logger.Warning("Wartung", "Schmiermittel-Stand bei 22% (Schwellwert 25%)");
    }
}