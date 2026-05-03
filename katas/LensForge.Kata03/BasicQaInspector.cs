using LensForge.Shared;

namespace LensForge.Kata03;

public interface IQaInspector
{
    QualityReport Inspect(Lens lens);
}

public class BasicQaInspector : IQaInspector
{
    public QualityReport Inspect(Lens lens)
    {
        Vis.Step("QA", $"Sichtprüfung an {lens.Id}");
        Thread.Sleep(300);

        var report = new QualityReport(lens);
        report.RecordCheck("Sichtprüfung (Kratzer/Risse/Verfärbungen)");

        // Simulierte Logik: Linsen mit Durchmesser unter 45mm haben
        // erfahrungsgemäß häufiger sichtbare Mängel
        if (lens.DiameterMm < 45)
            report.RecordDefect("Sichtbarer Kratzer am Rand");

        return report;
    }
}