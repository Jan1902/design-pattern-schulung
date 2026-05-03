using LensForge.Kata02.Legacy;
using LensForge.Shared;

namespace LensForge.Kata02.Solution;

internal class GrindingStationAdapter : IProductionStep
{
    private readonly LegacyGrindingSystem _legacy;

    public GrindingStationAdapter(LegacyGrindingSystem legacy)
    {
        _legacy = legacy;
    }

    public string Name => "Schleifen (Werk 2)";

    public StepResult Process(Lens lens)
    {
        var material = MapLensTypeToMaterial(lens.Type);
        var targetDiopter = 0;  // wird in dieser Anwendung nicht genutzt

        var status = _legacy.PerformGrind(lens.DiameterMm, material, targetDiopter);

        return status switch
        {
            GrindStatus.OK => new StepResult(true, "Geschliffen"),
            GrindStatus.BLANK_TOO_SMALL => new StepResult(false, "Linse zu klein"),
            GrindStatus.BLANK_TOO_THICK => new StepResult(false, "Linse zu dick"),
            GrindStatus.MACHINE_FAULT => new StepResult(false, "Maschinenfehler"),
            _ => new StepResult(false, "Unbekannter Status"),
        };
    }

    private static string MapLensTypeToMaterial(LensType type) => type switch
    {
        LensType.Standard => "CR-39",
        LensType.HighIndex => "POLY",
        LensType.Photochromic => "PHOTO",
        _ => "UNKNOWN",
    };
}
