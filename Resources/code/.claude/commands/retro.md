Führe eine Retrospektive für den zuletzt abgeschlossenen Sprint durch.

---

## Vorbereitung

1. Finde den zuletzt geschlossenen Sprint in `workspace/sprints/` (status: closed, neuestes Datum)
2. Lies alle Tasks die im Sprint waren (done + carried_over)
3. Lies `memory/patterns.md` und `memory/decisions.md` für Kontext aus vorherigen Retros
4. Lies alle Artefakte (Specs, ADRs, Code, Reviews) der Sprint-Tasks für inhaltliche Analyse

---

## Retro-Format (Start/Stop/Continue + Learnings)

Erstelle `workspace/retros/retro-SPRINT-XXX.md` mit folgender Struktur:

```markdown
# Retro — SPRINT-XXX
**Datum:** YYYY-MM-DD
**Sprint-Ziel:** ...
**Ergebnis:** X/Y Tasks abgeschlossen

## Was lief gut? (Continue)
- ...

## Was lief nicht gut? (Stop/Reduce)
- ...

## Was sollten wir anfangen? (Start)
- ...

## Learnings & Patterns
- ...

## Action Items
| # | Maßnahme | Verantwortlich | Fällig |
|---|----------|---------------|--------|
| 1 | ...      | Orchestrator  | ...    |

## Metriken
- Velocity: X Tasks abgeschlossen
- Carried over: X Tasks
- Neue ADRs: X
- Review-Findings (Ø): X pro Task
```

---

## Memory aktualisieren

Nach der Retro automatisch updaten:

1. **`memory/patterns.md`** — neue Patterns die sich im Sprint bewährt haben
2. **`memory/decisions.md`** — wichtige Entscheidungen die im Sprint gefallen sind
3. **Veraltetes entfernen** — Patterns die sich als falsch erwiesen haben

---

## Sprint verknüpfen

- Sprint-YAML updaten: `retro: workspace/retros/retro-SPRINT-XXX.md`

---

## Abschluss

Ausgabe: Zusammenfassung der wichtigsten Erkenntnisse und konkreten Action Items für den nächsten Sprint.
