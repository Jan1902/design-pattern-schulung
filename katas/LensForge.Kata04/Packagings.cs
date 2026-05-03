using LensForge.Shared;

namespace LensForge.Kata04;

public class PappkartonPackaging : IPackaging
{
    public string PackagingType => "Pappkarton";
    public string ShippingLabel => "Standard-Versand";
    public decimal Cost => 2.50m;

    public void PackLens(Lens lens)
    {
        Vis.Step("Verpackung", "Falte Pappkarton");
        Thread.Sleep(150);
        Vis.Step("Verpackung", "Lege Schaumstoff-Polsterung ein");
        Thread.Sleep(100);
        Vis.Step("Verpackung", $"Setze Linse {lens.Id} ein");
        Thread.Sleep(100);
        Vis.Step("Verpackung", "Verschließe mit Standard-Aufkleber");
    }
}

public class HolzkistePackaging : IPackaging
{
    public string PackagingType => "Holzkiste";
    public string ShippingLabel => "Optiker-Versand";
    public decimal Cost => 8.00m;

    public void PackLens(Lens lens)
    {
        Vis.Step("Verpackung", "Öffne Holzkiste");
        Thread.Sleep(200);
        Vis.Step("Verpackung", "Lege Mehrfach-Schaumstoff ein");
        Thread.Sleep(150);
        Vis.Step("Verpackung", $"Stecke Linse {lens.Id} in Schutzhülle");
        Thread.Sleep(100);
        Vis.Step("Verpackung", "Setze in Polsterung ein");
        Thread.Sleep(100);
        Vis.Step("Verpackung", "Verschließe mit Schraubdeckel");
    }
}

public class SterilboxPackaging : IPackaging
{
    public string PackagingType => "Sterilbox";
    public string ShippingLabel => "Labor-Versand (steril)";
    public decimal Cost => 15.00m;

    public void PackLens(Lens lens)
    {
        Vis.Step("Verpackung", "Entnehme Sterilbox aus Reinraum");
        Thread.Sleep(200);
        Vis.Step("Verpackung", "Prüfe Inertgas-Atmosphäre");
        Thread.Sleep(150);
        Vis.Step("Verpackung", $"Setze Linse {lens.Id} mit Pinzette ein");
        Thread.Sleep(150);
        Vis.Step("Verpackung", "Vakuum-versiegele Box");
        Thread.Sleep(150);
        Vis.Step("Verpackung", "Bringe Strichcode-Etikett an");
    }
}