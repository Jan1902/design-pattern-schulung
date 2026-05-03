using LensForge.Kata03;
using LensForge.Shared;

Vis.Header("LensForge — QA-Pipeline Demo");

// Kunde A: Standard + Beschichtungs-Haftung
// Kunde B: Standard + Schlagfestigkeit + UV-Durchlässigkeit
// Kunde C: Standard + alle drei Zusatzprüfungen

// TODO: Baut hier die drei Inspector-Konfigurationen auf.
//       Stellt sicher, dass jede Konfiguration die gewünschten
//       Prüfungen enthält.
//
// IQaInspector inspectorA = ???;
// IQaInspector inspectorB = ???;
// IQaInspector inspectorC = ???;

var lensA = new Lens("L-A01", LensType.HighIndex, 52);
var lensB = new Lens("L-B01", LensType.Standard, 56);
var lensC = new Lens("L-C01", LensType.Photochromic, 48);

// RunInspection(inspectorA, lensA, "Kunde A");
// RunInspection(inspectorB, lensB, "Kunde B");
// RunInspection(inspectorC, lensC, "Kunde C");

Vis.Step("Demo", "QA-Pipeline abgeschlossen.");

static void RunInspection(IQaInspector inspector, Lens lens, string customer)
{
    Vis.Separator();
    Vis.Step("QA", $"--- {customer} ---");
    Vis.Lens(lens);

    var report = inspector.Inspect(lens);

    Vis.Step("QA", $"Durchgeführte Prüfungen: {report.Checks.Count}");
    foreach (var check in report.Checks)
        Vis.Step("QA", $"  • {check}");

    if (report.Defects.Count > 0)
    {
        Vis.Step("QA", "Festgestellte Mängel:");
        foreach (var defect in report.Defects)
            Vis.Step("QA", $"  ✗ {defect}");
    }

    Vis.Result("QA gesamt", report.Passed,
               report.Passed ? null : "Linse hat QA nicht bestanden");
}