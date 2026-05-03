namespace LensForge.Kata02.Legacy;

// Externe Bibliothek "Werk 2 Grinding Control v1.4"
// Lizenziert vom Hersteller - Quellcode nicht modifizierbar
// Letztes Update: 2014

public enum GrindStatus
{
    OK = 0,
    BLANK_TOO_SMALL = 1,
    BLANK_TOO_THICK = 2,
    MACHINE_FAULT = 99
}

public class LegacyGrindingSystem
{
    public GrindStatus PerformGrind(double diameterMm, string material, int targetDiopter)
    {
        Console.WriteLine($"[LEGACY-GRIND] Starting grind cycle...");
        Console.WriteLine($"[LEGACY-GRIND]   Diameter: {diameterMm}mm");
        Console.WriteLine($"[LEGACY-GRIND]   Material: {material}");
        Console.WriteLine($"[LEGACY-GRIND]   Target diopter: {targetDiopter}");

        Thread.Sleep(700);

        if (diameterMm < 40)
            return GrindStatus.BLANK_TOO_SMALL;
        if (diameterMm > 80)
            return GrindStatus.BLANK_TOO_THICK;

        Console.WriteLine($"[LEGACY-GRIND] Grind cycle complete.");
        return GrindStatus.OK;
    }
}