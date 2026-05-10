# Kata 6: Maschinen-Statusüberwachung

## Kontext

Die LensForge-Anlage durchläuft während ihres Betriebs verschiedene Zustände: Start, Aufwärmen, Produktion, Wartung, Shutdown. Wenn die Maschine ihren Zustand wechselt, müssen mehrere Komponenten reagieren:
- Die **DisplayUnit** in der Werkshalle zeigt den aktuellen Status an
- Der **AuditLogger** schreibt jeden Zustandswechsel mit Zeitstempel weg
- Das **AlertSystem** schickt eine SMS, wenn die Maschine in Fehlerzustand geht
- Die **MetricsCollector** zählt, wie oft welcher Zustand erreicht wurde

Aktuell ist die `MachineController`-Klasse für all das selbst zuständig. Sie ruft bei jedem Zustandswechsel die anderen Komponenten direkt auf.

## Neue Anforderung

Die Werksleitung möchte eine neue Komponente einführen: einen **EmergencyShutdownHandler**, der bei einem Wechsel in den Fehlerzustand automatisch den MachineController herunterfahren lässt. Außerdem soll der AuditLogger zukünftig optional ein- und ausschaltbar sein (z.B. für Wartungsphasen).

## Eure Aufgabe

1. Refactored den `MachineController` so, dass er die einzelnen Komponenten nicht mehr direkt kennt. (D.h. keine direkten Aufrufe mehr im Controller. Abstrahiert von außen reingeben ist erlaubt!)
2. Stellt sicher, dass Komponenten sich zur Laufzeit registrieren und abmelden könnten
3. Implementiert den neuen `EmergencyShutdownHandler`
4. Ergänzt einen Test, der die Reaktion des EmergencyShutdownHandlers auf einen Fehlerzustand überprüft
5. Ergänzt einen Test, der die An- und Abmeldung des AuditLoggers überprüft — wenn er abgemeldet ist, soll er keine Einträge mehr schreiben
6. Startet `Program.cs` — die Maschine soll durch alle Zustände wandern, und alle Komponenten sollen entsprechend reagieren

Der `EmergencyShutdownHandler` könnte z.B. so aussehen:
```csharp
class EmergencyShutdownHandler
{
    public EmergencyShutdownHandler(MachineController controller)
    {
        // ...
    }

    // ...

    public void OnErrorState()
    {
        Console.WriteLine("Emergency shutdown initiated!");
        // ....
    }
}
```

## Zwänge

- `MachineController` darf nach dem Refactoring keine direkten Referenzen auf `DisplayUnit`, `AuditLogger`, `AlertSystem` oder `MetricsCollector` haben
- Komponenten sollen sich zur Laufzeit an- und abmelden können
- Eine neue Komponente einzubauen darf den Controller nicht verändern müssen

## Tipp

- Es geht heute um die Idee: *"Jemand kündigt eine Änderung an, viele hören zu — wer will."* Wer zuhört, entscheidet er selbst.
- Es gibt mehrere Wege, das umzusetzen. Es sind alle erlaubt, die den o.g. Zwängen genügen. Diskutiert im Pair, welche Variante ihr wählt und warum. Es gibt kein "richtig" oder "falsch" — es geht um die Prinzipien dahinter!