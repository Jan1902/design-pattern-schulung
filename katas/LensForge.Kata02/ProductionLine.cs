using LensForge.Shared;

namespace LensForge.Kata02;

public class ProductionLine
{
    private readonly List<IProductionStep> _steps;

    public ProductionLine(IEnumerable<IProductionStep> steps)
    {
        _steps = [.. steps];
    }

    public bool Run(Lens lens)
    {
        Vis.Lens(lens);
        foreach (var step in _steps)
        {
            Vis.Step(step.Name, $"Verarbeite {lens.Id}");
            var result = step.Process(lens);
            Vis.Result(step.Name, result.Success,
                       result.Success ? null : result.Message);

            if (!result.Success)
            {
                Vis.Step(step.Name, "Linie gestoppt wegen Fehler.");
                return false;
            }
        }

        return true;
    }
}