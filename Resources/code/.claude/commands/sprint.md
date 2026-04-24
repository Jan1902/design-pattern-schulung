Sprint-Management. Aufruf: /sprint <subcommand> [argumente]

Lies zuerst `workspace/sprints/` um den aktuellen Zustand zu verstehen (aktiver Sprint, letzte Sprint-ID).

---

## Subcommands

### /sprint start [ziel]

Starte einen neuen Sprint.

1. Prüfe ob bereits ein aktiver Sprint existiert (`status: active` in einem Sprint-File) — falls ja, Fehler ausgeben: "Es gibt bereits einen aktiven Sprint. Erst `/sprint close` ausführen."
2. Bestimme nächste Sprint-ID (letzte ID + 1, start bei SPRINT-001)
3. Zeige alle Tasks aus `workspace/backlog/` an
4. Frage welche Tasks in den Sprint kommen (oder nimm `$ARGUMENTS` wenn Tasks dort angegeben)
5. Erstelle `workspace/sprints/SPRINT-XXX.yaml` nach Template
   - goal: aus $ARGUMENTS oder nachfragen
   - start: heute
   - end: heute + 14 Tage (Standard, anpassbar)
   - tasks: ausgewählte Tasks
   - status: active
6. Verschiebe ausgewählte Task-YAMLs von `workspace/backlog/` nach `workspace/in_progress/`
7. Ausgabe: Sprint-Übersicht mit Ziel, Zeitraum, Tasks

---

### /sprint status

Zeige den aktuellen Sprint-Status.

1. Finde aktiven Sprint in `workspace/sprints/` (status: active)
2. Lies Tasks aus `workspace/in_progress/` und `workspace/done/` um echten Status zu ermitteln
3. Ausgabe als übersichtliche Tabelle:
   - Sprint-Ziel und Zeitraum
   - Tasks mit Status (backlog / in_progress / done)
   - Fortschritt: X/Y Tasks abgeschlossen
   - Verbleibende Tage

---

### /sprint close

Schließe den aktiven Sprint ab.

1. Finde aktiven Sprint
2. Gleiche Sprint-Tasks gegen `workspace/done/` ab — was ist fertig, was nicht?
3. Nicht fertige Tasks: Status auf `carried_over` setzen
4. Update Sprint-YAML:
   - status: closed
   - metrics.completed: Anzahl Done-Tasks
   - metrics.carried_over: Anzahl nicht erledigter Tasks
5. Carried-over Tasks zurück nach `workspace/backlog/` verschieben
6. Sprint-YAML abschließen
7. Hinweis ausgeben: "Sprint geschlossen. Führe `/retro` aus um die Retrospektive zu starten."

---

### /sprint list

Zeige alle Sprints (kurze Übersicht: ID, Ziel, Status, Completed/Total).
