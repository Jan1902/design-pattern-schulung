using LensForge.Shared;

namespace LensForge.Kata06.Solution;

public class MachineController
{
    public MachineState CurrentState { get; private set; } = MachineState.Idle;

    // Das Event ersetzt die direkten Referenzen auf alle Komponenten
    public event Action<MachineState, MachineState>? OnStateChanged;

    public void TransitionTo(MachineState newState)
    {
        var oldState = CurrentState;
        CurrentState = newState;

        OnStateChanged?.Invoke(oldState, newState);
    }
}
