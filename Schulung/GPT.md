# Schulung: Design Patterns in C\#

**Zielgruppe:** Werkstudenten & Junior Devs bei adesso
**Dauer:** 1,5 Tage, Präsenz
**Gruppengröße:** bis 8 Teilnehmer
**Voraussetzung:** OOP-Grundlagen (Klassen, Interfaces, Vererbung, Polymorphie) sitzen; C#-Grundkenntnisse
**Sprache:** C# / .NET

---

## Lernziele

Nach der Schulung können die Teilnehmer:

1. erklären, was ein Design Pattern ist, wozu es dient und wozu nicht
2. die drei GoF-Kategorien (Creational, Structural, Behavioral) voneinander abgrenzen
3. die wichtigsten 10–12 Patterns erkennen und in eigenen Code einführen
4. einschätzen, wann ein Pattern hilft und wann es "Over-Engineering" wäre
5. typische Anti-Patterns benennen und vermeiden

---

## Methodik

- **Input-Phasen max. 40–45 min**, dann Wechsel auf Diskussion oder Kata
- **Pattern-Einstieg immer über ein Problem** ("Hier riecht der Code komisch — warum?"), nicht über die Lösung
- **Drei Katas als roter Faden:** eine pro Kategorie, aufbauend in Komplexität
- **Pair Programming** (3–4 Teams à 2 Personen) bei Katas, **Mob Programming** beim Lösungs-Review
- **UML-Klassendiagramme** zu jedem Pattern an der Tafel/Whiteboard, nicht nur auf Folien — die Teilnehmer sollen sie selbst nachzeichnen
- **Repository** mit Starter- und Musterlösungen wird zu Beginn geteilt; Musterlösungen bleiben bis zum Review "verschlossen"

---

## Material (vor dem Termin vorbereiten)

- Laptops mit .NET 8 SDK + IDE (Rider oder Visual Studio 2022)
- Git-Zugang zum Schulungs-Repo (Katas)
- Whiteboard/Flipchart für UML-Skizzen
- Moderationskarten für Erwartungsabfrage & Feedback
- Namensschilder / Tischkarten
- Getränke, Snacks, Mittagessen organisiert

---

## Tag 1 (ganztägig, ~8 h brutto)

### Block 1 — Einstieg & Fundament (09:00 – 10:30, 90 min)

| Zeit | Inhalt | Methode |
|---|---|---|
| 09:00 – 09:20 | Begrüßung, Vorstellung, Erwartungsabfrage | Moderationskarten: "Was erwarte ich?" / "Was bringe ich mit?" |
| 09:20 – 09:50 | **Was sind Design Patterns?** Geschichte (GoF 1994), Definition, Nutzen, Grenzen | Input + Diskussion |
| 09:50 – 10:15 | **SOLID als Fundament** — warum Patterns ohne SOLID nicht funktionieren; Live-Refactoring eines SRP-/OCP-Verstoßes | Live-Coding am Beamer |
| 10:15 – 10:30 | **UML-Klassendiagramm-Crashkurs:** Assoziation, Aggregation, Komposition, Vererbung, Interface-Realisierung | Whiteboard |

**Lerngewinn:** Teilnehmer wissen, *warum* Patterns existieren und haben die Notation im Kopf, um sie zu lesen.

### Pause (10:30 – 10:45)

### Block 2 — Creational Patterns (10:45 – 12:30, 105 min)

| Zeit | Inhalt | Methode |
|---|---|---|
| 10:45 – 11:10 | **Singleton** — Aufbau, .NET-Varianten (Lazy<T>, statischer Konstruktor), DI-Container-Alternative, Fallstricke (Testbarkeit, Hidden Dependencies) | Input + Code-Demo |
| 11:10 – 11:45 | **Factory Method** — Problem: `new` verteilt im Code; Lösung; Abgrenzung zum Abstract Factory | Input + Code-Demo |
| 11:45 – 12:10 | **Abstract Factory** — Familie von Objekten, Beispiel Theming/Cross-Platform | Input + Code-Demo |
| 12:10 – 12:25 | **Builder** — Fluent API, wann statt Konstruktor-Teleskop | Input |
| 12:25 – 12:30 | **Prototype** (kurzer Überblick, nur "kennen") | Input |

### Mittagspause (12:30 – 13:30)

### Block 3 — Kata 1: Factory Method (13:30 – 15:00, 90 min)

| Zeit | Inhalt | Methode |
|---|---|---|
| 13:30 – 13:45 | Aufgabenvorstellung: **Notification-System** (E-Mail, SMS, Push) mit hässlichem `if/else`-Dispatcher → in Factory Method refactoren | Live |
| 13:45 – 14:40 | **Hands-on** in Pairs | Pair Programming |
| 14:40 – 15:00 | **Lösungs-Review** — ein Team zeigt, die anderen diskutieren; Musterlösung gegenüberstellen | Mob-Review |

**Zwischenreflexion:** "Was war heute einfacher/schwerer als gedacht?"

### Pause (15:00 – 15:15)

### Block 4 — Structural Patterns (15:15 – 17:00, 105 min)

| Zeit | Inhalt | Methode |
|---|---|---|
| 15:15 – 15:40 | **Adapter** — Legacy-Integration, Ports & Adapters kurz anreißen | Input + Code-Demo |
| 15:40 – 16:15 | **Decorator** — Open/Closed in Reinform; Bezug zu ASP.NET Core Middleware | Input + Code-Demo |
| 16:15 – 16:40 | **Facade** — komplexe Subsysteme kapseln; Abgrenzung Mediator | Input |
| 16:40 – 17:00 | **Composite** — Baumstrukturen, Datei-/Menü-Beispiel | Input |

### Block 5 — Recap & Ausblick (17:00 – 17:30, 30 min)

| Zeit | Inhalt | Methode |
|---|---|---|
| 17:00 – 17:15 | **Blitzlicht-Quiz:** 5 Code-Schnipsel, welches Pattern ist das? | Plenum |
| 17:15 – 17:30 | Zusammenfassung, Ausblick Tag 2, Fragen offenhalten | Plenum |

---

## Tag 2 (halbtags, ~4 h brutto)

### Block 6 — Behavioral Patterns (09:00 – 10:45, 105 min)

| Zeit | Inhalt | Methode |
|---|---|---|
| 09:00 – 09:15 | **Warm-up / Recap Tag 1** — jeder Teilnehmer nennt ein Pattern + ein Beispiel | Plenum-Runde |
| 09:15 – 09:45 | **Strategy** — austauschbare Algorithmen; Bezug zu C# `Func<>`/Delegates als "leichtgewichtige Strategy" | Input + Code-Demo |
| 09:45 – 10:15 | **Observer** — Events vs. `IObservable<T>` vs. klassisches Observer-Interface | Input + Code-Demo |
| 10:15 – 10:35 | **Command** — Undo/Redo, Queueing, CQRS-Andeutung | Input |
| 10:35 – 10:45 | **Template Method & State** im Schnelldurchlauf | Input |

### Pause (10:45 – 11:00)

### Block 7 — Kata 2: Strategy + Observer (11:00 – 12:30, 90 min)

| Zeit | Inhalt | Methode |
|---|---|---|
| 11:00 – 11:15 | Aufgabenvorstellung: **ShoppingCart** mit wechselnden Rabattstrategien + Observer für Logging/Statistik | Live |
| 11:15 – 12:10 | **Hands-on** in Pairs — zwei Patterns kombinieren | Pair Programming |
| 12:10 – 12:30 | **Lösungs-Review** — Fokus auf Kombinierbarkeit & Testbarkeit | Mob-Review |

### Block 8 — Abschluss (12:30 – 13:00, 30 min)

| Zeit | Inhalt | Methode |
|---|---|---|
| 12:30 – 12:45 | **Anti-Patterns & Pattern Overuse** — "Patternitis", Golden Hammer, Speculative Generality. Merksatz: *"Ein Pattern ist die Antwort auf ein Problem. Ohne Problem keine Antwort."* | Input + Diskussion |
| 12:45 – 12:55 | **Weiterlernen:** Literaturtipps (Freeman/Freeman "Head First Design Patterns", refactoring.guru, Fowler "Patterns of Enterprise Application Architecture"), Katas-Repo mit **Kata 3 (Decorator)** als Hausaufgabe | Input |
| 12:55 – 13:00 | **Feedback-Runde** — "Eine Sache, die ich mitnehme / Eine Sache, die gefehlt hat" | Blitzlicht |

---

## Was bewusst NICHT dabei ist

- **Prototype, Flyweight, Bridge, Interpreter, Memento, Visitor, Mediator, Chain of Responsibility, Iterator** → max. als Name gefallen. Bei Juniors überfordert die Breite mehr als sie nutzt. Hinweis auf refactoring.guru zum Selbststudium.
- **Architektur-Patterns** (MVC, CQRS, Hexagonal, Clean Architecture) → eigene Schulung, nicht hier.
- **DDD** → nur am Rand erwähnt, kein Fokus.

---

## Patterns-Matrix: Was behandeln wir wie intensiv?

| Pattern | Kategorie | Tiefe | Live-Coding? |
|---|---|---|---|
| Singleton | Creational | Solide | Ja |
| Factory Method | Creational | **Tief (Kata 1)** | Ja |
| Abstract Factory | Creational | Solide | Ja |
| Builder | Creational | Kurz | Nein |
| Prototype | Creational | Erwähnt | Nein |
| Adapter | Structural | Solide | Ja |
| Decorator | Structural | **Tief (Kata 3 Hausaufgabe)** | Ja |
| Facade | Structural | Kurz | Nein |
| Composite | Structural | Kurz | Nein |
| Strategy | Behavioral | **Tief (Kata 2)** | Ja |
| Observer | Behavioral | **Tief (Kata 2)** | Ja |
| Command | Behavioral | Solide | Nein |
| Template Method | Behavioral | Kurz | Nein |
| State | Behavioral | Kurz | Nein |

---

## Checkliste für dich (eine Woche vor dem Termin)

- [ ] Repo mit Katas und Starter-Projekten bereitstellen (Link vorab an Teilnehmer)
- [ ] .NET 8 SDK + IDE-Installation als Vorab-Aufgabe bei Teilnehmern anfragen
- [ ] Folien review: bei jedem Pattern ein echtes adesso-/Projekt-Beispiel einbauen (nicht nur Auto-Fabriken)
- [ ] UML-Spickzettel ausdrucken (eine Seite pro Teilnehmer)
- [ ] Quiz-Fragen Tag 1 und Feedbackformular vorbereiten
- [ ] Raum-Setup: U-Form oder 4er-Tische für Pair-Programming

## Checkliste für den Morgen des Schulungstags

- [ ] Beamer/HDMI testen
- [ ] WLAN-Zugang für Teilnehmer
- [ ] Kaffee, Wasser, Snacks
- [ ] Starter-Repo nochmal klonen und selber durchlaufen (Kata läuft?)
- [ ] Backup-Plan wenn Technik streikt: Katas sind offline durchführbar (nur `dotnet run`)
