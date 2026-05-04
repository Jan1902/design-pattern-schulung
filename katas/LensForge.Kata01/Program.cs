using LensForge.Kata01;
using LensForge.Shared;

Vis.Header("LensForge — Coating-Modul Demo");

var station = new CoatingStation();

var jobs = new[]
{
            (new Lens("L-001", LensType.Standard, 52),     "anti-reflex", 80),
            (new Lens("L-002", LensType.HighIndex, 54),    "hardening",   100),
            (new Lens("L-003", LensType.Photochromic, 50), "uv-filter",   75),

            // Diese zwei sind aktuell auskommentiert — nach eurem Refactor
            // sollen sie funktionieren:

            // (new Lens("L-004", LensType.Standard, 56), "blue-light-premium", 90),
            // (new Lens("L-005", LensType.HighIndex, 52), "mirror",            100),
        };

foreach (var (lens, type, intensity) in jobs)
{
    Vis.Separator();
    Vis.Lens(lens);
    var result = station.ApplyCoating(lens, type, intensity);
    Vis.Result(result.CoatingApplied, result.Success, result.ErrorMessage);
}

Vis.Separator();
Vis.Step("Demo", "Alle Linsen verarbeitet.");
