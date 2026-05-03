using LensForge.Kata02;
using LensForge.Kata02.Legacy;
using LensForge.Shared;

Vis.Header("LensForge — Linie mit Legacy-Schleifmaschine");

var legacy = new LegacyGrindingSystem();

// TODO: Hier müsst ihr die Legacy-Maschine so verpacken, dass sie 
//       als IProductionStep in die ProductionLine passt.
//
// IProductionStep grindStep = new ???(legacy);

var line = new ProductionLine(
[
            new CleaningStation(),
            // grindStep,            <-- hier soll eure Lösung rein
            new PolishingStation(),
]);

var lens = new Lens("L-101", LensType.Standard, 52);
line.Run(lens);

Vis.Separator();
Vis.Step("Demo", "Linie abgeschlossen.");