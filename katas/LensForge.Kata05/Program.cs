using LensForge.Kata05;
using LensForge.Shared;

Vis.Header("LensForge — Logging-Modul Demo");

// Aktuell hat jede Klasse ihren eigenen Logger.
// Nach eurem Refactor sollten alle drei denselben Logger nutzen.
var assembly = new AssemblyLine();
var maintenance = new MaintenanceUnit();
var quality = new QualityGate();

var lenses = new[]
{
    new Lens("L-001", LensType.Standard, 52),
    new Lens("L-002", LensType.HighIndex, 40), // wird ablehnt
    new Lens("L-003", LensType.Photochromic, 50),
};

foreach (var lens in lenses)
{
    Vis.Separator();
    assembly.ProcessLens(lens);
    quality.Check(lens);
}

Vis.Separator();
maintenance.RunDiagnostics();

Vis.Separator();
Vis.Step("Demo", "Schaut in die production.log — wie viele Datei-Handles wurden geöffnet?");

// Nach eurem Refactor: setzt das LogLevel HIER zentral auf Warning. 
// Alle Module sollen ab jetzt nur noch Warnings und Errors loggen.
//
// Vis.Separator();
// Vis.Step("Demo", "Zweiter Lauf mit MinimumLevel = Warning");
//
// foreach (var lens in lenses)
// {
//     assembly.ProcessLens(lens);   // sollte still bleiben
//     quality.Check(lens);          // nur Errors loggen
// }
