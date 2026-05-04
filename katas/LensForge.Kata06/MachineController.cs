using LensForge.Shared;

namespace LensForge.Kata06;

public class MachineController
{
    private readonly DisplayUnit _display;
    private readonly AuditLogger _audit;
    private readonly AlertSystem _alerts;
    private readonly MetricsCollector _metrics;

    public MachineState CurrentState { get; private set; } = MachineState.Idle;

    // Der Konstruktor wird mit jeder neuen Komponente erweitert.
    public MachineController(
        DisplayUnit display,
        AuditLogger audit,
        AlertSystem alerts,
        MetricsCollector metrics)
    {
        _display = display;
        _audit = audit;
        _alerts = alerts;
        _metrics = metrics;
    }

    public void TransitionTo(MachineState newState)
    {
        var oldState = CurrentState;
        CurrentState = newState;

        // Hier wird jede Komponente direkt aufgerufen.
        // Jede neue Komponente erfordert eine Anpassung an dieser Stelle.
        _display.UpdateStatus(newState);
        _audit.LogTransition(oldState, newState);
        _metrics.RecordTransition(newState);

        if (newState == MachineState.Error)
            _alerts.SendAlert($"Maschine im Fehlerzustand! Vorher: {oldState}");
    }
}
