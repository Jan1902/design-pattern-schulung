using LensForge.Shared;

namespace LensForge.Kata02;

public class CleaningStation : IProductionStep
{
    public string Name => "Reinigung";
    public StepResult Process(Lens lens)
    {
        Thread.Sleep(200);
        return new StepResult(true, "OK");
    }
}

public class PolishingStation : IProductionStep
{
    public string Name => "Polieren";
    public StepResult Process(Lens lens)
    {
        Thread.Sleep(300);
        return new StepResult(true, "OK");
    }
}