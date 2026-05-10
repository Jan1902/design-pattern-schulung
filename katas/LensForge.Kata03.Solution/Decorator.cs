using LensForge.Shared;

namespace LensForge.Kata03.Solution;

internal abstract class QaInspectorDecorator : IQaInspector
{
    private readonly IQaInspector _inner;

    protected QaInspectorDecorator(IQaInspector inner)
    {
        _inner = inner;
    }

    public QualityReport Inspect(Lens lens)
    {
        var report = _inner.Inspect(lens);
        AddOwnCheck(lens, report);
        return report;
    }

    protected abstract void AddOwnCheck(Lens lens, QualityReport report);
}

internal class CoatingAdhesionCheck : QaInspectorDecorator
{
    public CoatingAdhesionCheck(IQaInspector inner) : base(inner) { }

    protected override void AddOwnCheck(Lens lens, QualityReport report)
    {
        Vis.Step("QA", "Beschichtungs-Haftungsprüfung");
        Thread.Sleep(200);
        report.RecordCheck("Beschichtungs-Haftung");

        // Simulierter Defekt
        if (lens.Type == LensType.Photochromic && lens.DiameterMm < 50)
            report.RecordDefect("Haftungsschwäche an Beschichtung");
    }
}

internal class ImpactResistanceCheck : QaInspectorDecorator
{
    public ImpactResistanceCheck(IQaInspector inner) : base(inner) { }

    protected override void AddOwnCheck(Lens lens, QualityReport report)
    {
        if (report.Defects.Count > 0)
        {
            Vis.Step("QA", "Schlagfestigkeitsprüfung übersprungen wegen vorherigen Defekten");
            report.RecordCheck("Schlagfestigkeit übersprungen");
            return;
        }

        Vis.Step("QA", "Schlagfestigkeitsprüfung");
        Thread.Sleep(250);
        report.RecordCheck("Schlagfestigkeit");
    }
}

internal class UvTransmissionCheck : QaInspectorDecorator
{
    public UvTransmissionCheck(IQaInspector inner) : base(inner) { }

    protected override void AddOwnCheck(Lens lens, QualityReport report)
    {
        Vis.Step("QA", "UV-Durchlässigkeitsmessung");
        Thread.Sleep(150);
        report.RecordCheck("UV-Durchlässigkeit");
    }
}
