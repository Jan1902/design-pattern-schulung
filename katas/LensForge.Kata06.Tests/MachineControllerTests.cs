using LensForge.Shared;

namespace LensForge.Kata06.Tests;

public class MachineControllerTests
{
    [Fact]
    public void MetricsCollector_RecordsTransitionsCorrectly()
    {
        var displayUnit = new DisplayUnit();
        var auditLogger = new AuditLogger();
        var alertSystem = new AlertSystem();
        var metricsCollector = new MetricsCollector();

        var controller = new MachineController(displayUnit, auditLogger, alertSystem, metricsCollector);

        // Passt die Tests an eure Implementierung an und stellt sicher, dass sie nach dem Refactoring noch funktionieren.

        controller.TransitionTo(MachineState.StartingUp);
        controller.TransitionTo(MachineState.Producing);

        Assert.Equal(2, metricsCollector.TotalTransitions);
    }

    // Ergänzt weitere Tests, um die Funktionalität eures Controllers und der einzelnen Komponenten zu überprüfen.
}
