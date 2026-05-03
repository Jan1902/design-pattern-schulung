# Kata 4: Verpackungs-Modul

## Kontext

Bevor LensForge fertige Linsen zum Versand bringt, werden sie verpackt. 
Je nach Kunde unterscheidet sich, wie verpackt wird:

- **Endkunden** bekommen ihre Linsen in einem schlichten Pappkarton mit 
  Standard-Schaumstoff-Polsterung.
- **Optiker-Großkunden** bekommen die Linsen in einer Holzkiste mit 
  Mehrfach-Polsterung — passend für den Versand mehrerer Linsen.
- **Labore** bekommen die Linsen in einer sterilen Spezial-Box mit 
  Inertgas-Atmosphäre.

Das Modul hat die Aufgabe, für einen gegebenen Auftrag die richtige 
Verpackung zu bauen und die Linse einzupacken. Die `ShippingPreparation` 
ist die Klasse, die das aktuell macht.

## Neue Anforderungen

Bisher gibt es nur den Endkunden-Versand. Jetzt sollen die anderen 
beiden Verpackungsarten dazukommen — und in absehbarer Zeit ist auch 
ein **Express-Versand mit Sicherheits-Versiegelung** geplant.

Das Verpacken selbst (also was *passiert*, wenn eine Linse in eine 
Verpackung kommt) unterscheidet sich pro Verpackungsart leicht: 
Polsterung, Versiegelung, Etikettierung sind unterschiedlich.

## Eure Aufgabe

1. Schaut euch `ShippingPreparation.cs` an. Was stört euch?
2. Refactored den Code so, dass die Verantwortung für die *Auswahl 
   und Erzeugung* der passenden Verpackung von der eigentlichen 
   Versand-Vorbereitung getrennt ist.
3. Implementiert die zwei fehlenden Verpackungsarten 
   (Optiker-Holzkiste, Labor-Sterilbox).
4. Startet `Program.cs` — drei verschiedene Aufträge sollen mit ihrer 
   jeweils passenden Verpackung durchlaufen.

## Zwänge

- `ShippingPreparation` darf den Verpackungs-Typ nicht selbst 
  per `if/else` oder `switch` auswählen
- `ShippingPreparation` darf die konkreten Verpackungs-Klassen 
  (Pappkarton, Holzkiste, Sterilbox) nicht direkt kennen — sie 
  arbeitet nur mit einer Abstraktion
- Eine neue Verpackungsart einzubauen darf das Hinzufügen *einer* 
  neuen Klasse plus *einen* Eintrag an *einer* zentralen Stelle 
  erfordern — mehr nicht

## Tipp

Es gibt zwei Aspekte, die ihr trennen müsst: *welche* Verpackung 
genommen wird (das hängt vom Kundentyp ab) und *was* eine Verpackung 
genau tut (das ist pro Verpackung unterschiedlich). Wenn ihr beides 
in einer Klasse mischt, baut ihr euch Probleme.