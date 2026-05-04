using LensForge.Kata06;
using LensForge.Shared;

Console.WriteLine("=== LensForge — Maschinen-Statusüberwachung ===\n");

// TODO: Nach eurem Refactoring werden die Komponenten hier
//       angemeldet, statt sie dem Controller direkt zu übergeben.
//
//   var controller = new MachineController();
//   controller.Subscribe(new DisplayUnit().UpdateStatus);
//   ... usw.

var controller = new MachineController(
    new DisplayUnit(),
    new AuditLogger(),
    new AlertSystem(),
    new MetricsCollector());

// Simulierter Tagesablauf der Maschine
controller.TransitionTo(MachineState.StartingUp);
Thread.Sleep(300);
controller.TransitionTo(MachineState.Producing);
Thread.Sleep(300);
controller.TransitionTo(MachineState.Error);
Thread.Sleep(300);
controller.TransitionTo(MachineState.Maintenance);
Thread.Sleep(300);
controller.TransitionTo(MachineState.Producing);
Thread.Sleep(300);
controller.TransitionTo(MachineState.ShuttingDown);

Console.WriteLine("\n=== Demo abgeschlossen ===");
