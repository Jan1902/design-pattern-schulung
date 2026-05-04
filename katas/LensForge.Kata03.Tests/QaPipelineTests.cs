using LensForge.Shared;

namespace LensForge.Kata03.Tests;

public class QaPipelineTests
{
    [Fact]
    public void CustomerA_PerformsTwoChecks()
    {
        var inspector = BuildInspectorForCustomerA();
        var lens = new Lens("L-T01", LensType.HighIndex, 52);

        var report = inspector.Inspect(lens);

        Assert.Equal(2, report.Checks.Count);
    }

    [Fact]
    public void CustomerB_PerformsThreeChecks()
    {
        var inspector = BuildInspectorForCustomerB();
        var lens = new Lens("L-T02", LensType.Standard, 50); // keine Prüfung löst hier einen Defekt aus

        var report = inspector.Inspect(lens);

        Assert.Equal(3, report.Checks.Count);
    }

    [Fact]
    public void CustomerC_PerformsFourChecks()
    {
        var inspector = BuildInspectorForCustomerC();
        var lens = new Lens("L-T03", LensType.Photochromic, 50); // keine Prüfung löst hier einen Defekt aus

        var report = inspector.Inspect(lens);

        Assert.Equal(4, report.Checks.Count);
    }

    [Fact]
    public void CustomerB_ReusesSameChecksAsCustomerC_OnlyDifferentCombination()
    {
        // Diese Test stellt sicher, dass die einzelnen Prüfungen
        // wiederverwendbar sind und nicht für jeden Kunden neu erfunden werden.
        var inspectorB = BuildInspectorForCustomerB();
        var inspectorC = BuildInspectorForCustomerC();

        var lens = new Lens("L-T04", LensType.Standard, 52);
        var reportB = inspectorB.Inspect(lens);
        var reportC = inspectorC.Inspect(lens);

        // Alle Prüfungen aus B müssen auch in C vorkommen
        foreach (var check in reportB.Checks)
            Assert.Contains(check, reportC.Checks);
    }

    // TODO: Diese Builder-Methoden müsst ihr füllen.
    //       Sie sollen IQaInspector-Instanzen liefern, die zu den 
    //       jeweiligen Kunden-Anforderungen passen.

    private IQaInspector BuildInspectorForCustomerA()
        => throw new NotImplementedException();

    private IQaInspector BuildInspectorForCustomerB()
        => throw new NotImplementedException();

    private IQaInspector BuildInspectorForCustomerC()
        => throw new NotImplementedException();
}
