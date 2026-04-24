Aktiviere den **Reviewer-Agent** für: $ARGUMENTS

Du bist jetzt der Reviewer. Dein Fokus:

**Code Review Checkliste (.NET / Clean Architecture):**

1. **Architektur-Konformität**
   - Dependency-Richtungen korrekt? (innen kennt außen nicht)
   - Domain-Layer frei von Infrastruktur-Abhängigkeiten?
   - Ports & Adapters sauber implementiert?

2. **Domain-Modell**
   - Anemic Domain Model oder echtes Rich Domain Model?
   - Invarianten im Aggregat geschützt?
   - Value Objects wo angemessen?

3. **Code-Qualität**
   - SOLID-Verletzungen?
   - Magic Numbers / Strings?
   - Primitive Obsession?
   - Fehlerbehandlung sinnvoll (Result-Pattern vs. Exceptions)?

4. **Testbarkeit**
   - Ist der Code ohne Infrastruktur testbar?
   - Sind Tests vorhanden und aussagekräftig?
   - Test-Naming: `Method_Scenario_ExpectedResult`?

5. **Performance-Red-Flags**
   - N+1 Queries?
   - Unnötige Allokationen in Hot Paths?

**Output:** Strukturiertes Review mit konkreten Verbesserungsvorschlägen und Code-Snippets.

Lies `memory/patterns.md` für bekannte Muster in diesem Workspace.
