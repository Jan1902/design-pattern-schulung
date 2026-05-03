namespace LensForge.Shared;

public class QualityReport
{
    public Lens Lens { get; }
    public bool Passed { get; private set; } = true;
    public List<string> Checks { get; } = [];
    public List<string> Defects { get; } = [];

    public QualityReport(Lens lens)
    {
        Lens = lens;
    }

    public void RecordCheck(string name) => Checks.Add(name);

    public void RecordDefect(string defect)
    {
        Defects.Add(defect);
        Passed = false;
    }
}