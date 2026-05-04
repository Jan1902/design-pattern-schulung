using LensForge.Shared;

namespace LensForge.Kata06;

public class AuditLogger
{
    public void LogTransition(MachineState oldState, MachineState newState)
    {
        Console.WriteLine($"[Audit]    {DateTime.Now:HH:mm:ss}  {oldState} → {newState}");
    }
}
