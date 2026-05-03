using LensForge.Shared;

namespace LensForge.Kata05;

public class QualityGate
{
    private readonly ProductionLogger _logger = new ProductionLogger();

    public bool Check(Lens lens)
    {
        _logger.Info("QualityGate", $"Prüfe Linse {lens.Id}");
        Thread.Sleep(150);

        var passed = lens.DiameterMm >= 45;

        if (passed)
            _logger.Info("QualityGate", $"Linse {lens.Id}: BESTANDEN");
        else
            _logger.Error("QualityGate", $"Linse {lens.Id}: ABGELEHNT (Durchmesser {lens.DiameterMm}mm)");

        return passed;
    }
}