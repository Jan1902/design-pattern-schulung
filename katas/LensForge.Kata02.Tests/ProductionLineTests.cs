using LensForge.Shared;

namespace LensForge.Kata02.Tests;

public class ProductionLineTests
{
    [Fact]
    public void Line_ProcessesValidLensThroughAllSteps()
    {
        var lens = new Lens("L-T01", LensType.Standard, 52);
        var line = BuildLineWithLegacyGrinder();

        var success = line.Run(lens);

        Assert.True(success);
    }

    [Fact]
    public void Line_StopsWhenLensTooSmall()
    {
        var lens = new Lens("L-T02", LensType.Standard, 30);
        var line = BuildLineWithLegacyGrinder();

        var success = line.Run(lens);

        Assert.False(success);
    }

    private ProductionLine BuildLineWithLegacyGrinder()
    {
        // TODO: Hier müsst ihr die Linie aufbauen, inklusive eurer Lösung für die Legacy-Schleifmaschine.
        throw new NotImplementedException();
    }
}
