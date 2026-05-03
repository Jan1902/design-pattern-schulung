# Code Smells
- Bloaters
- Object-Orientation-Abusers
- Change Preventers
- Dispensables
- Couplers

# Design Patterns
## Structural
### Decorator
Erweitert ein Objekt dynamisch um Verhalten, ohne die Klasse zu verändern. Sehr anschaulich und gut mit dem Open/Closed-Prinzip verknüpfbar.

Praxis: Erweitern von Framework-Komponenten oder Legacy
### Adapter
Macht zwei inkompatible Schnittstellen kompatibel — wie ein Reisestecker. Begegnet Einsteigern sofort in der Praxis (z. B. beim Einbinden externer Libraries).

Praxis: Adaptieren an Framework-Komponenten oder Legacy
### Facade
Bietet eine vereinfachte Schnittstelle zu einem komplexen Subsystem. Leicht verständlich und motiviert das Prinzip der Kapselung.

Praxis: Oft unbewusst, indem man Services zusammenfasst
## Creational
### Factory Method
Auslagerung der Objekterzeugung in eine Methode oder Unterklasse. Hilft, Code vom konkreten Typ zu entkoppeln — ein zentrales OOP-Prinzip.

Praxis: In Form von injizierten Factory Klassen
### Singleton
Stellt sicher, dass eine Klasse nur eine einzige Instanz hat (z. B. Konfiguration, Logger). Einsteigerfreundlich, aber mit Vorsicht zu genießen — oft übermäßig eingesetzt.

Praxis: Mittels IoC Containern und Service Lifetimes
## Behavioral
### Observer
Ein Objekt benachrichtigt Abonnenten bei Zustandsänderungen (Events, Callbacks). Fundamental für UI, Event-Driven-Systeme und Reaktivität.

Praxis: Events oder Mediator
### Command
Kapselt eine Aktion als Objekt — ermöglicht Undo/Redo, Queuing und Logging. Praktisch greifbar (z. B. Button-Aktionen, Transaktionen).

Praxis: Messaging, Caching, Outbox, etc.
### Strategy
Wechselbare Algorithmen hinter einer gemeinsamen Schnittstelle. Sehr gut geeignet, um das Open/Closed-Prinzip zu veranschaulichen.

Praxis: Injizierte Klasse für verschiedene Strategien
## Praxis & Frameworks
- Mediator
- Builder
- Template Methods
- IoC Container