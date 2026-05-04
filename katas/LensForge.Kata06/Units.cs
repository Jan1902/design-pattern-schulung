// DisplayUnit.cs
using LensForge.Shared;

namespace LensForge.Kata06;

public class DisplayUnit
{
    public void UpdateStatus(MachineState state)
    {
        Console.WriteLine($"[Display]  Anzeige aktualisiert: {state}");
    }
}
