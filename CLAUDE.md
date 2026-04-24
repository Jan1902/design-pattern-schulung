# Projekt: Design Patterns Schulung

## Was ist das hier?

Ein **Obsidian-Vault**, der alle Materialien für eine 1,5-tägige Präsenz-Schulung zu Design Patterns enthält. Die Schulung findet bei **adesso SE** statt. Trainer ist **Jan Heinbokel** (Senior Engineer @ adesso SE, Software-Architekt bei ZEISS).

---

## Zielgruppe & Rahmenbedingungen

- **Teilnehmer:** Werkstudenten & Junior Devs bei adesso, ~9 Personen
- **Vorwissen:** OOP-Grundlagen (Klassen, Interfaces, Vererbung, Polymorphie), C#-Grundkenntnisse, vorherige SOLID-Schulung bereits absolviert
- **Dauer:** 1,5 Tage Präsenz (Tag 1 ganztägig, Tag 2 halbtags)
- **Programmiersprache:** C# / .NET 8

---

## Inhaltlicher Fokus

Die Schulung behandelt **GoF Design Patterns** — bewusst auf ca. 10–12 der wichtigsten beschränkt, keine Vollständigkeit um der Vollständigkeit willen.

**Behandelte Patterns (nach Tiefe):**

| Kategorie | Tief (Kata) | Solide | Kurz/Erwähnt |
|---|---|---|---|
| Creational | Factory Method | Singleton, Abstract Factory | Builder, Prototype |
| Structural | Decorator (Hausaufgabe) | Adapter | Facade, Composite |
| Behavioral | Strategy, Observer (Kata 2) | Command | Template Method, State |

Bewusst ausgelassen: Flyweight, Bridge, Interpreter, Memento, Visitor, Mediator, Chain of Responsibility, Iterator — sowie Architektur-Patterns (CQRS, Clean Architecture, DDD).

**Didaktisches Prinzip:** Einstieg immer über das Problem (Code Smell), nie über die Lösung. Pattern als Antwort — nicht als Selbstzweck.

---

## Struktur des Vaults

```
/
├── Schulung/
│   ├── Praesentation.md        # Haupt-Präsentation (obsidian-advanced-slides / reveal.js)
│   ├── GPT.md                  # Detaillierter Schulungsplan mit Zeitplan, Methodik, Checklisten
│   ├── Rahmenbedingungen.md    # Eckdaten (Dauer, Zielgruppe, etc.)
│   ├── Zeitplan.md             # Grober Zeitplan
│   └── Katas/                  # Coding-Übungen (in Aufbau)
├── Resources/
│   ├── images/                 # Bilder für die Präsentation
│   └── code/                   # Claude Code Workspace (eigene CLAUDE.md vorhanden)
│       ├── CLAUDE.md           # Eigener Kontext für den Code-Workspace (Agents, ADRs, etc.)
│       ├── memory/             # Persistentes Memory-System für Claude Code
│       └── workspace/          # Backlog, Sprints, Artefakte
├── Alte Notizen/               # Frühe Planungsnotizen (Ablauf, wichtige Inhalte)
├── adesso Unterlagen/          # Company-Dokumente (Trainer-Tipps, KI-Illustrationen, etc.)
├── Presentation.pptx           # PPTX-Export der Präsentation
└── Start.md                    # SessionLab-Link
```

---

## Präsentationsformat

`Schulung/Praesentation.md` verwendet das **obsidian-advanced-slides** Plugin (reveal.js-basiert). Folien werden durch `---` getrennt, Layouts über `<grid>`-Tags gesteuert, Hintergründe via `data-background-gradient`. Theme: `black`, Highlight: `monokai`.

---

## Was noch fehlt / in Arbeit ist

Laut `TODO.md` und der GPT-Datei noch ausstehend:
- Katas-Repository mit Starter- und Musterlösungen
- Kata 1: Notification-System (Factory Method)
- Kata 2: ShoppingCart mit Strategy + Observer
- Kata 3 (Hausaufgabe): Decorator
- UML-Spickzettel (ein Seiter pro Teilnehmer)
- Echte adesso/Projekt-Beispiele in den Folien statt generische Beispiele
- Quiz-Fragen für den Blitzlicht-Check Tag 1
