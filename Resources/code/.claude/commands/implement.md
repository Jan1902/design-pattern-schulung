Starte einen vollständigen **Implementierungs-Zyklus** für: $ARGUMENTS

Als Orchestrator koordinierst du folgende Schritte:

**1. Requirements klären** (Requirements Engineer Sub-Agent)
- Was genau soll gebaut werden?
- Akzeptanzkriterien definieren
- Spec unter `workspace/artifacts/specs/` ablegen

**2. Architektur-Check** (Architect Sub-Agent)
- Passt die Implementierung zur bestehenden Architektur?
- Welche Patterns sind angemessen?
- ADR wenn nötig

**3. Implementierung** (Developer Sub-Agent)
- C#/.NET Code nach Clean Architecture Prinzipien
- SOLID, Clean Code
- Code unter `workspace/artifacts/code/` ablegen

**4. Tests** (Tester Sub-Agent)
- Unit Tests mit xUnit + FluentAssertions + NSubstitute
- Integration Tests wo sinnvoll
- Tests unter `workspace/artifacts/tests/` ablegen

**5. Review** (Reviewer Sub-Agent)
- Code Review gegen Architektur-Konformität
- Best Practices Check
- Feedback einarbeiten

**6. Task abschließen**
- Task von `in_progress/` nach `done/` verschieben
- Learnings in Memory festhalten

Lies zuerst `memory/patterns.md` und `memory/preferences.md` für Kontext.
Erstelle einen Task in `workspace/backlog/` bevor du startest.
