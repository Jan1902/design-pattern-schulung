# Design-Pattern-Katas (C# / .NET 8)

Drei aufeinander aufbauende Katas für die adesso-Schulung. Jede Kata besteht aus:

- `Starter/` — lauffähiger, aber "schlecht" strukturierter Code. Das ist der Ausgangspunkt.
- `Solution/` — eine mögliche Refactoring-Lösung. Wird **erst nach der Bearbeitung** angesehen!
- `README.md` — Aufgabenstellung, Hinweise, Akzeptanzkriterien.

## Übersicht

| Kata | Patterns | Kategorie | Bearbeitungszeit |
|---|---|---|---|
| 01 – Notification-System | Factory Method | Creational | ~55 min (Tag 1) |
| 02 – ShoppingCart | Strategy + Observer | Behavioral | ~55 min (Tag 2) |
| 03 – Kaffeehaus | Decorator | Structural | ~45 min (Hausaufgabe) |

## Voraussetzung

- .NET 8 SDK (`dotnet --version` zeigt `8.x`)
- IDE: Rider, Visual Studio 2022 oder VS Code mit C#-Extension

## So startest du eine Kata

```bash
cd Kata-01-Factory/Starter
dotnet run
```

Die Starter-Projekte sind **bewusst** lauffähig — erst verstehen, dann refactoren.

## Spielregeln Pair-Programming

- **Rollen:** Driver (tippt) und Navigator (denkt/liest).
- **Wechsel alle 10 Minuten** — bei Kata 2 gern auch alle 7 Minuten (Pomodoro-Style).
- **Tests zuerst anpassen**, dann Code.
- **Wenn ihr fertig denkt:** wieder starten und prüfen, ob sich neue Anforderungen (siehe README "Stretch Goals") leicht einbauen lassen. Das ist der eigentliche Lackmustest für ein gutes Pattern.
