---
theme: black
highlightTheme: monokai
---

<!-- .slide: data-background-gradient="linear-gradient(135deg, #1a1a2e 0%, #16213e 60%, #0f3460 100%)" -->

<grid drag="100 100" drop="0 0" align="center">

# Design Patterns in C# <!-- element style="font-size: 2.6em; font-weight: 700; letter-spacing: 0.04em;" -->

### Workshop · adesso SE <!-- element style="color: #aaa; margin-top: 0.5em; font-weight: 300;" -->

</grid>

---

<!-- .slide: data-background-gradient="linear-gradient(135deg, #1a1a2e 0%, #16213e 100%)" -->

<grid drag="40 100" drop="0 0" align="center">

<img src="Resources/images/Profile.jpg" style="border-radius: 50%; width: 200px; height: 200px; object-fit: cover; object-position: center top; border: 3px solid rgba(255,255,255,0.2); margin-bottom: 0.8em;" />

**Jan Heinbokel**

</grid>

<grid drag="55 90" drop="44 5" align="left">

## Wer bin ich?

<br/>

🏢 **Senior Engineer** @ adesso SE

🔭 **Software-Architekt** im Kundenprojekt @ ZEISS

💡 Leidenschaft für sauberen, wartbaren Code

📚 Heute: Design Patterns — Werkzeug, kein Selbstzweck

</grid>

---

<!-- .slide: data-background-gradient="linear-gradient(135deg, #1a1a2e 0%, #16213e 100%)" -->

## Was ist ein Design Pattern?

<br/>

> *"A design pattern describes a problem that occurs over and over again in our environment, and then describes the core of the solution to that problem."*
>
> — Christopher Alexander, 1977

<br/>

<grid drag="90 30" drop="5 60" align="center">

Ein Design Pattern ist eine **bewährte, wiederverwendbare Lösung** für ein **wiederkehrendes Problem** in einem bestimmten Kontext.

Es ist kein fertiger Code — sondern eine **Schablone**, die du auf deine Situation anpasst.

</grid>

---

<!-- .slide: data-background-gradient="linear-gradient(135deg, #1a1a2e 0%, #16213e 100%)" -->

<grid drag="48 100" drop="0 0" align="center">

## Die Gang of Four

<br/>

<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/e3/DesignPatterns.jpg/330px-DesignPatterns.jpg" style="width: 160px; border-radius: 8px; border: 2px solid rgba(255,255,255,0.15);" />

<br/>

**1994** — Erich Gamma, Richard Helm,
Ralph Johnson, John Vlissides

</grid>

<grid drag="48 90" drop="51 5" align="left">

<br/><br/>

📖 **"Design Patterns: Elements of Reusable Object-Oriented Software"**

<br/>

- 23 klassische Patterns dokumentiert
- Gemeinsame Sprache für Entwickler geschaffen
- Bis heute Referenzwerk der Softwareentwicklung

<br/>

> Wer "GoF" sagt, meint dieses Buch.

</grid>

---

<!-- .slide: data-background-gradient="linear-gradient(135deg, #1a1a2e 0%, #16213e 100%)" -->

## Warum gibt es Design Patterns?

<br/>

<grid drag="30 55" drop="2 30" align="center" style="background: rgba(255,255,255,0.05); border-radius: 12px; padding: 1em;">

### 😵 Das Problem

Code der wächst, wird komplex. Dieselben Probleme tauchen immer wieder auf — in jedem Projekt, in jeder Firma.

</grid>

<grid drag="30 55" drop="35 30" align="center" style="background: rgba(255,255,255,0.05); border-radius: 12px; padding: 1em;">

### 💬 Die Sprache

Patterns geben uns ein gemeinsames Vokabular. *"Mach das mit einem Strategy Pattern"* — und alle wissen, was gemeint ist.

</grid>

<grid drag="30 55" drop="68 30" align="center" style="background: rgba(255,255,255,0.05); border-radius: 12px; padding: 1em;">

### ✅ Die Lösung

Bewährte Lösungsansätze, die von erfahrenen Entwicklern erprobt wurden — nicht bei Null anfangen.

</grid>

---

<!-- .slide: data-background-gradient="linear-gradient(135deg, #1a1a2e 0%, #16213e 100%)" -->

## Wann hilft ein Pattern — wann nicht?

<br/>

<grid drag="45 65" drop="2 25" align="left" style="background: rgba(34,197,94,0.1); border: 1px solid rgba(34,197,94,0.3); border-radius: 12px; padding: 1em 1.2em;">

### ✅ Pattern einsetzen wenn…

- Das konkrete Problem vorhanden ist
- Der Code ohne es schwer erweiterbar wäre
- Das Team die Lösung versteht

</grid>

<grid drag="45 65" drop="52 25" align="left" style="background: rgba(239,68,68,0.1); border: 1px solid rgba(239,68,68,0.3); border-radius: 12px; padding: 1em 1.2em;">

### ❌ Pattern vermeiden wenn…

- Das Problem noch gar nicht existiert
- Es den Code komplizierter macht
- Du es nur des Patterns willen einsetzen willst

</grid>

<grid drag="90 12" drop="5 88" align="center">

> *"Ein Pattern ist die Antwort auf ein Problem. Ohne Problem — keine Antwort."*

</grid>

---

<!-- .slide: data-background-gradient="linear-gradient(135deg, #1a1a2e 0%, #16213e 100%)" -->

## Die drei Kategorien

<br/>

<grid drag="30 62" drop="2 28" align="center" style="background: rgba(165,216,255,0.08); border: 1px solid rgba(165,216,255,0.25); border-radius: 12px; padding: 1em;">

### 🏗️ Creational

**Objekterzeugung**

Wie werden Objekte erstellt? Wer ist verantwortlich?

<br/>

`Singleton` · `Factory Method`
`Abstract Factory` · `Builder`
`Prototype`

</grid>

<grid drag="30 62" drop="35 28" align="center" style="background: rgba(208,191,255,0.08); border: 1px solid rgba(208,191,255,0.25); border-radius: 12px; padding: 1em;">

### 🧩 Structural

**Objektstruktur**

Wie werden Klassen und Objekte zu größeren Strukturen zusammengesetzt?

<br/>

`Adapter` · `Decorator`
`Facade` · `Composite`
`Proxy` · `Bridge`

</grid>

<grid drag="30 62" drop="68 28" align="center" style="background: rgba(178,242,187,0.08); border: 1px solid rgba(178,242,187,0.25); border-radius: 12px; padding: 1em;">

### 🔄 Behavioral

**Objektverhalten**

Wie kommunizieren Objekte? Wer übernimmt welche Verantwortung?

<br/>

`Strategy` · `Observer`
`Command` · `Template Method`
`State` · `Mediator`

</grid>
