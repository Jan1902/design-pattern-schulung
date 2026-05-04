# Kata 3: QA-Pipeline mit Zusatzprüfungen

## Kontext

Jede Linse, die LensForge produziert, durchläuft am Ende der Linie eine Qualitätskontrolle. Aktuell gibt es eine Klasse `BasicQaInspector`, die eine Standard-Sichtprüfung durchführt: Sie schaut auf Kratzer, Risse und Verfärbungen.

```csharp
public interface IQaInspector
{
    QualityReport Inspect(Lens lens);
}
```

Der bestehende Inspector funktioniert gut und wird seit langer Zeit in Produktion eingesetzt. Er soll **nicht angefasst werden**.

## Neue Anforderungen

Drei Kunden haben in den letzten Wochen unterschiedliche zusätzliche Prüfungen verlangt:

- **Kunde A** (Premium-Brillenmarke): Möchte zusätzlich eine **Beschichtungs-Haftungsprüfung**. Nur für seine Bestellungen.

- **Kunde B** (Sportoptik-Hersteller): Möchte eine **Schlagfestigkeitsprüfung** UND eine **UV-Durchlässigkeitsmessung**.

- **Kunde C** (medizinisches Gerätegeschäft): Braucht alle drei Zusatzprüfungen *plus* die Standard-Sichtprüfung — und alles muss sauber im Bericht dokumentiert sein für die FDA.

Wichtig: Welche Prüfungen kombiniert werden, ist von Auftrag zu Auftrag unterschiedlich. Ein Kunde könnte morgen schon eine vierte Kombination verlangen.

## Was die einzelnen Prüfungen tun sollen

Damit ihr nicht über die Details der Logik nachdenken müsst, hier die fachlichen Anforderungen pro Prüfung. Die Defekt-Kriterien sind bewusst einfach gehalten — in der Realität wären das echte Messwerte.

### Beschichtungs-Haftungsprüfung
- Simuliert einen Klebebandtest auf der Linsenoberfläche
- Fehlerfall: Photochromatische Linsen mit Durchmesser unter 50mm zeigen erfahrungsgemäß Haftungsschwächen
- Defekt-Meldung: "Beschichtung löst sich beim Klebebandtest"

### Schlagfestigkeitsprüfung
- Drop-Ball-Test: Stahlkugel fällt aus 1,27m auf die Linse (FDA-Standard)
- Fehlerfall: Standard-Linsen mit Durchmesser über 55mm bekommen Mikrorisse
- Defekt-Meldung: "Mikroriss nach Drop-Ball-Test"

### UV-Durchlässigkeitsmessung
- Spektrometer-Messung der UV-Transmission
- Fehlerfall: Standard-Linsen ab 54mm Durchmesser überschreiten den Grenzwert von 1% UV-Durchlässigkeit
- Defekt-Meldung: "UV-Durchlässigkeit über 1% (Grenzwert überschritten)"

## Eure Aufgabe

1. Schaut euch `BasicQaInspector.cs` an.
2. Findet einen Weg, die zusätzlichen Prüfungen einzubauen, sodass beliebige Kombinationen möglich sind — ohne den `BasicQaInspector` anzufassen.
3. Implementiert die drei neuen Prüfungen.
4. Startet `Program.cs` — die drei Kunden-Szenarien sollten alle ihre passenden Prüfungen durchlaufen.

## Zwänge

- `BasicQaInspector` darf nicht verändert werden
- `IQaInspector`-Interface darf nicht verändert werden
- Kein einziges `if (kunde == "A") ...` im Code — die Auswahl der Prüfungen wird beim Aufbau der Inspektion entschieden, nicht zur Laufzeit innerhalb einer Klasse
- Jede Prüfung soll für sich allein einsetzbar sein — eine Schlagfestigkeitsprüfung könnte theoretisch auch ohne Standard-Sichtprüfung laufen

## Tipp

Wenn ihr darüber nachdenkt, eine `SuperQaInspector`-Klasse zu bauen, die alle möglichen Prüfungen kennt und per Konfiguration ein- und ausschaltet — haltet inne. Das wäre Strategy mit zu vielen Kontrollen am falschen Ort. Heute geht's um *Komposition*: Wie könnt ihr Prüfungen *aufeinander stapeln*?
