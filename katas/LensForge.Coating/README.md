# Kata 1: Coating-Modul

## Kontext

LensForge bietet seinen Kunden Beschichtungen für ihre Linsen an. Die `CoatingStation` ist die Maschine, die diese Beschichtungen aufträgt.

Aktuell unterstützt die Station drei Verfahren: Anti-Reflex, Härtung und UV-Filter. Der Code dafür ist über die letzten Monate gewachsen.

## Neue Anforderung

Das Produktteam hat heute zwei neue Coating-Verfahren angekündigt, die nächste Woche in Produktion gehen sollen:

- **Blue-Light-Filter** (Standard und Premium — unterscheiden sich in der Auftragsdauer und in der erforderlichen Mindestintensität)
- **Mirror-Coating** (verspiegelte Sonnenbrillen-Optik)

Außerdem hat sich der Marketing-Bereich beschwert: Die aktuelle Implementierung ist schwer zu testen, und neue Verfahren einzubauen dauert immer länger.

## Eure Aufgabe

1. Schaut euch `CoatingStation.cs` an. Was stört euch daran? Diskutiert kurz im Pair, *bevor* ihr Code anfasst.
2. Refactored die Station so, dass die zwei neuen Verfahren problemlos hinzugefügt werden können.
3. Implementiert die neuen Verfahren.
4. Startet `Program.cs` — alle fünf Linsen sollten erfolgreich beschichtet durch die Station laufen.

## Zwänge

- Die `ApplyCoating`-Methode der `CoatingStation` darf nach eurem Refactoring **nicht länger als 10 Zeilen** sein.
- Neue Coating-Verfahren dürfen den bestehenden Code der bereits vorhandenen Verfahren nicht anfassen.
- Jedes Coating-Verfahren soll **isoliert testbar** sein (ein Test pro Verfahren, ohne dass die Station gemockt werden muss).

## Hinweis zur Strategie-Registrierung

Wo werden die einzelnen Coating-Verfahren der Station bekannt gemacht? Diskutiert das im Pair, bevor ihr anfangt. Eine einfache Möglichkeit: Im Konstruktor der Station selbst. Es gibt elegantere Wege — die schauen wir uns am Tag 2 an. Heute reicht eine pragmatische Lösung.

## Tipp

Wenn ihr im Pair feststellt, dass ihr die `ApplyCoating`-Methode nur "ein bisschen" verlängern wollt, um die neuen Verfahren einzubauen — haltet inne. Das ist genau der Reflex, den ihr heute überwinden lernt.
