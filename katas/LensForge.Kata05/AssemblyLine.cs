using LensForge.Shared;

namespace LensForge.Kata05;

public class AssemblyLine
{
    private readonly ProductionLogger _logger = new ProductionLogger();

    public void ProcessLens(Lens lens)
    {
        _logger.Info("AssemblyLine", $"Starte Verarbeitung von Linse {lens.Id}");
        Thread.Sleep(200);
        _logger.Info("AssemblyLine", $"Linse {lens.Id} verarbeitet");
    }
}