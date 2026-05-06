# Kata 5: Logger-Singleton

## Kontext

Bisher haben unsere Module `Vis.Step()`-Calls genutzt, um Aktionen in der Konsole zu zeigen. Das war für die Demo praktisch, aber für eine echte Fertigungsstrecke reicht das nicht: Die Werksleitung will nachvollziehbare Log-Dateien mit Zeitstempeln, Log-Levels (Info, Warning, Error) und einer einheitlichen Formatierung.

In der Codebase gibt es deshalb eine Klasse `ProductionLogger` mit diesen Anforderungen:

- Sie schreibt jede Log-Zeile mit Zeitstempel und Level in die Konsole
- Sie schreibt **dieselbe** Zeile zusätzlich in eine Log-Datei (`production.log`)
- Sie erlaubt das Setzen eines minimalen Log-Levels (z.B. nur Warning und Error in Produktion)

## Das Problem

Aktuell wird `ProductionLogger` an verschiedenen Stellen einfach mit `new ProductionLogger()` instanziiert. Das hat in den letzten Wochen zu mehreren Problemen geführt:

1. Jede Instanz öffnet ihren *eigenen* Datei-Handle für `production.log`. Bei vielen gleichzeitigen Zugriffen kommt es zu unvollständigen Zeilen oder verlorenen Einträgen.
2. Wenn die Werksleitung das Log-Level zur Laufzeit hochsetzt ("nur noch Errors anzeigen"), gilt das nur für *eine* Instanz — die anderen loggen weiter wie bisher.
3. Die Log-Dateien werden nicht sauber geschlossen, weil niemand weiß, wer der "letzte" Logger war.

## Eure Aufgabe

1. Schaut euch `ProductionLogger.cs` an. Versteht, was er tut.
2. Refactored den Logger so, dass es *garantiert nur eine einzige Instanz* gibt, egal von wo aus zugegriffen wird.
3. Refactored die Aufrufer-Klassen (`AssemblyLine`, `MaintenanceUnit`, `QualityGate`) so, dass sie diese gemeinsame Instanz nutzen — und nicht selbst eine erzeugen.
4. Startet `Program.cs`. Alle Module sollen in dieselbe Log-Datei schreiben, mit konsistenter Formatierung.

## Zwänge

- Die Logger-Instanz darf nicht in der Program.cs instanziiert werden.
- Es darf zur Laufzeit nur **genau eine** `ProductionLogger`-Instanz existieren
- Aufrufer dürfen den Logger nicht per `new ProductionLogger()` selbst erzeugen
- Wenn die Werksleitung das Log-Level ändert, muss diese Änderung *sofort überall* greifen
- Der Logger muss **thread-safe** sein — mehrere Module könnten parallel loggen wollen

## Testbarkeit

- Welche Probleme könnten beim getrennten Testen der Komponnten auffallen?
- In einem zweiten Schritt sollt ihr eine Möglichkeit schaffen, den Logger für Unit Tests gegen einen `InMemoryLogger` zu ersetzten, dessen Einträge ihr überprüfen könnt. Ist das überhaupt möglich?

```csharp
// Beispiel für einen InMemoryLogger im Test:
class InMemoryLogger : ???
{
    public LogLevel MinimumLevel { get; set; } = LogLevel.Info;
    public List<string> Entries { get; } = [];
    public void Info(string source, string message) => Entries.Add($"[Info] {message}");
    public void Warning(string source, string message) => Entries.Add($"[Warning] {message}");
    public void Error(string source, string message) => Entries.Add($"[Error] {message}");
}
```

## Tipp

Es gibt zwei Hauptvarianten, das zu lösen — eine naive und eine thread-safe. Versucht erst die naive, dann diskutiert im Pair, wo sie kaputt geht und wie ihr das fixt.
