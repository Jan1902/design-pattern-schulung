Führe den vollständigen Feature-Workflow für folgendes durch: $ARGUMENTS

Du bist der Orchestrator. Arbeite die folgenden Schritte sequenziell ab. Jeder Schritt baut auf dem vorherigen auf.

---

## Schritt 1 — Requirements Engineer

Spawne einen RE-Sub-Agent mit folgender Aufgabe:
- Analysiere die Anforderung, triff explizite Annahmen wo nötig
- Schreibe User Stories mit Given/When/Then Akzeptanzkriterien
- Dokumentiere Edge Cases und Fehlerszenarien
- Lege Spec unter `workspace/artifacts/specs/YYYY-MM-DD-<titel>.md` ab
- Erstelle Task-YAML unter `workspace/backlog/TASK-XXX-<titel>.yaml` (nächste freie ID)

Warte auf Ergebnis, lies die Spec.

---

## Schritt 2 — Architect

Spawne einen Architect-Sub-Agent mit folgender Aufgabe:
- Lies die Spec aus Schritt 1
- Erstelle Architektur-Konzept: Projektstruktur, Komponenten, Fehlerbehandlungsstrategie, Testbarkeit
- Nutze passende .NET 10 / C# 13 Patterns, kein Over-Engineering
- Lege Konzept unter `workspace/artifacts/adr/YYYY-MM-DD-<titel>-architecture.md` ab

Warte auf Ergebnis, lies das Konzept.

---

## Schritt 3 — Developer

Spawne einen Developer-Sub-Agent mit folgender Aufgabe:
- Lies Spec + Architektur-Konzept
- Implementiere vollständig nach Spec und ADR
- .NET 10 / C# 13, alle User Stories und Edge Cases abgedeckt
- Code unter `workspace/artifacts/code/<titel>/`
- Task-Status auf `in_progress` setzen

Warte auf Ergebnis.

---

## Schritt 4 — Reviewer

Spawne einen Reviewer-Sub-Agent mit folgender Aufgabe:
- Lies Spec, ADR und Implementierung
- Prüfe: Spec-Konformität, Architektur-Konformität, Code-Qualität, Fehlerbehandlung, Tests
- Erstelle `REVIEW.md` direkt im Code-Verzeichnis
- Urteil: "Approved", "Approved with minor changes", oder "Changes required"

Warte auf Ergebnis.

---

## Schritt 5 — Developer (nur wenn nötig)

Falls der Reviewer "Changes required" oder "Approved with minor changes" zurückgegeben hat:
- Spawne erneut Developer-Sub-Agent
- Alle Findings aus REVIEW.md einarbeiten
- `dotnet test` ausführen, alle Tests grün sicherstellen

Überspringe diesen Schritt wenn "Approved".

---

## Schritt 6 — Tester

Spawne einen Tester-Sub-Agent mit folgender Aufgabe:
- Bewerte und vervollständige die Test-Suite gegen die Spec (alle US + Edge Cases)
- Fehlende Tests direkt ergänzen
- `dotnet test` ausführen
- Test-Report unter `workspace/artifacts/tests/<task-id>-test-report.md` erstellen
- Urteil: "Abgenommen" oder "Nachbesserung erforderlich"

---

## Abschluss

- Task-YAML von `workspace/backlog/` nach `workspace/done/` verschieben, Status auf `done`
- Kurze Zusammenfassung: was wurde gebaut, alle Tests grün, offene Punkte falls vorhanden
