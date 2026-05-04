using LensForge.Shared;

namespace LensForge.Kata06;

public class MetricsCollector
{
    private readonly Dictionary<MachineState, int> _counts = new();

    public int TotalTransitions => _counts.Values.Sum();

    public void RecordTransition(MachineState state)
    {
        _counts[state] = _counts.GetValueOrDefault(state, 0) + 1;
        Console.WriteLine($"[Metrics]  {state} erreicht ({_counts[state]}x insgesamt)");
    }
}
