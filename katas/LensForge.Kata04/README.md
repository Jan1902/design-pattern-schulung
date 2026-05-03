# Kata 4: Verpackungs-Modul

## Kontext

Bevor LensForge fertige Linsen zum Versand bringt, werden sie verpackt. 
Je nach Kundentyp gibt es drei Verpackungsarten:

- **Endkunden** → Pappkarton mit Schaumstoff
- **Optiker-Großkunden** → Holzkiste mit Mehrfach-Polsterung
- **Labore** → Sterilbox mit Inertgas

Die drei Verpackungsarten sind bereits implementiert. Sie liegen als 
`PappkartonPackaging`, `HolzkistePackaging` und `SterilboxPackaging` 
vor und implementieren alle das `IPackaging`-Interface. **Diese Dateien 
sollt ihr nicht anfassen** — sie funktionieren.

## Das Problem

Die Logik *welche Verpackung für welchen Kunden* ist im Codebase 
verstreut. Schaut euch `ShippingPreparation`, `OrderProcessor` und 
`InvoiceWriter` an — alle drei treffen dieselbe Entscheidung 
("Endkunde → Pappkarton") an unterschiedlichen Stellen, mit leicht 
unterschiedlicher Logik. Das führt regelmäßig zu Bugs, wenn jemand 
die Regeln in einer der drei Klassen ändert und die anderen vergisst.

## Neue Anforderung

Demnächst kommen zwei weitere Kundentypen dazu:

- **Express-Versand** → bekommt eine versiegelte Sicherheits-Box
- **Großhandel international** → bekommt eine verstärkte Holzkiste 
  mit Zollpapieren

Außerdem hat das Produktteam angedeutet, dass irgendwann eine 
*kundenspezifische Verpackung* möglich sein soll (z.B. ein 
VIP-Kunde, der seine eigene Box-Marke wünscht).

## Eure Aufgabe

1. Schaut euch `ShippingPreparation`, `OrderProcessor` und 
   `InvoiceWriter` an. Findet die duplizierte Logik.
2. Räumt diese Logik so auf, dass sie an *einer* Stelle existiert 
   und alle drei Klassen sie nutzen.
3. Implementiert die zwei fehlenden Verpackungs-Klassen 
   (`ExpressSecureBox`, `ReinforcedExportCrate`).
4. Bindet die neuen Verpackungen in eure Lösung ein.
5. Startet `Program.cs` — alle fünf Kundentypen sollen mit der 
   richtigen Verpackung verarbeitet werden.

## Zwänge

- `IPackaging` und die existierenden Verpackungs-Klassen werden 
  nicht angefasst
- Keine Klasse außerhalb eurer Lösung soll *direkt* eine konkrete 
  Verpackungs-Klasse instanziieren (`new PappkartonPackaging()` ist 
  nur an einer einzigen Stelle erlaubt)
- Die Entscheidung "welche Verpackung pro Kundentyp" steht an 
  *genau einer* Stelle im Code

## Tipp

Es geht heute nicht darum, *was* eine Verpackung tut — das ist 
schon implementiert. Es geht darum, *wer* entscheidet, welche 
Verpackung erzeugt wird, und wie diese Entscheidung sauber 
zentralisiert wird.