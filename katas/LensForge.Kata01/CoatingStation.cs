using LensForge.Shared;

namespace LensForge.Kata01;

public class CoatingStation
{
    private const string Station = "Coating";

    public CoatingResult ApplyCoating(Lens lens, string type, int intensity)
    {
        Vis.Step(Station, $"Verarbeite Linse {lens.Id} ({type})");

        if (type == "anti-reflex")
        {
            if (intensity < 30)
                return new CoatingResult(lens, "AR", false, "Intensität zu niedrig für AR");

            Vis.Step(Station, "Trage Anti-Reflex-Schicht auf");
            Thread.Sleep(400);
            Vis.Step(Station, "Härte UV-aktiv aus");
            Thread.Sleep(200);

            return new CoatingResult(lens, "AR", true, null);
        }
        else if (type == "hardening")
        {
            if (lens.Type == LensType.Photochromic)
                return new CoatingResult(lens, "Hardening", false, "Härtung nicht für photochromatische Linsen");

            Vis.Step(Station, "Trage Härtungsschicht auf");
            Thread.Sleep(600);

            return new CoatingResult(lens, "Hardening", true, null);
        }
        else if (type == "uv-filter")
        {
            if (intensity < 50)
                return new CoatingResult(lens, "UV", false, "Intensität zu niedrig für UV-Filter");

            Vis.Step(Station, "Trage UV-Filterschicht auf");
            Thread.Sleep(500);
            Vis.Step(Station, "Versiegele Oberfläche");
            Thread.Sleep(300);

            return new CoatingResult(lens, "UV", true, null);
        }
        else
        {
            throw new NotSupportedException($"Coating-Verfahren '{type}' ist nicht unterstützt");
        }
    }
}