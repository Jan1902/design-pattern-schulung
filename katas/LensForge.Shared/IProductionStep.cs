namespace LensForge.Shared;

public interface IProductionStep
{
    string Name { get; }
    StepResult Process(Lens lens);
}

public record StepResult(bool Success, string Message);