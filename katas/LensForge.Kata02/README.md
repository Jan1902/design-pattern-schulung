# Kata 2: Legacy-Schleifmaschine integrieren

## Kontext

LensForge betreibt seit Jahren eine moderne Linsen-Fertigungsstrecke. Alle 
Stationen folgen einem einheitlichen Interface `IProductionStep`, das von 
der `ProductionLine` orchestriert wird:

```csharp
public interface IProductionStep
{
    string Name { get; }
    StepResult Process(Lens lens);
}
```

Die `ProductionLine` ruft jede Station mit `Process(lens)` auf und bekommt 
ein einheitliches `StepResult` zurück. Das funktioniert seit zwei Jahren 
einwandfrei.

## Neue Anforderung

Wegen Lieferengpässen muss kurzfristig eine **alte Schleifmaschine aus 
Werk 2** in die Linie integriert werden. Diese Maschine wird über eine 
externe Bibliothek `LegacyGrindingSystem` angesteuert — das ist 
herstellerseitig gelieferter Code, der sich **nicht ändern lässt**.

Das Problem: Die Legacy-Maschine hat eine völlig andere API. Sie kennt 
weder `IProductionStep` noch `Lens` noch `StepResult`. Sie erwartet 
ihre eigenen Datentypen und liefert ihre eigenen Statuscodes zurück.

## Eure Aufgabe

1. Schaut euch `LegacyGrindingSystem.cs` an. Diese Datei dürft ihr 
   **nicht verändern** — stellt euch vor, sie kommt als kompilierte DLL 
   vom Hersteller.
2. Schaut euch `ProductionLine.cs` an. Auch diese Datei sollt ihr 
   **nicht anfassen** — sie funktioniert für die anderen Stationen ja 
   einwandfrei.
3. Findet einen Weg, die Legacy-Maschine in die `ProductionLine` 
   einzubauen.
4. Startet `Program.cs` — die Legacy-Maschine soll als ganz normale 
   Station in der Linie laufen.
5. Schreibt mindestens zwei Tests, die euer Refactoring absichern.

## Zwänge

- `LegacyGrindingSystem` darf nicht angefasst werden
- `ProductionLine` darf nicht angefasst werden  
- `IProductionStep` darf nicht erweitert werden

## Tipp

Wenn ihr das Gefühl habt, das Problem ließe sich nur lösen, indem 
ihr eine der "verbotenen" Dateien ändert — diskutiert kurz im Pair, 
warum das vermutlich keine gute Idee ist. (In der Realität würdet 
ihr nicht die DLL des Herstellers patchen, oder?)