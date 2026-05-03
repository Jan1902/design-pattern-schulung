using LensForge.Shared;

namespace LensForge.Kata04.Solution;

public class ExpressSecureBox : IPackaging
{
    public string PackagingType => "Sicherheits-Box";
    public string ShippingLabel => "Express-Versand (versiegelt)";
    public decimal Cost => 12.00m;

    public void PackLens(Lens lens)
    {
        Vis.Step("Verpackung", "Öffne Sicherheits-Box");
        Thread.Sleep(150);
        Vis.Step("Verpackung", "Lege antistatische Polsterung ein");
        Thread.Sleep(100);
        Vis.Step("Verpackung", $"Setze Linse {lens.Id} ein");
        Thread.Sleep(100);
        Vis.Step("Verpackung", "Bringe Sicherheitssiegel an");
        Thread.Sleep(100);
        Vis.Step("Verpackung", "Aktiviere GPS-Tracker");
    }
}

public class ReinforcedExportCrate : IPackaging
{
    public string PackagingType => "Verstärkte Holzkiste";
    public string ShippingLabel => "Internationaler Großhandel";
    public decimal Cost => 22.00m;

    public void PackLens(Lens lens)
    {
        Vis.Step("Verpackung", "Öffne verstärkte Export-Holzkiste");
        Thread.Sleep(200);
        Vis.Step("Verpackung", "Lege Stoßfest-Polsterung ein");
        Thread.Sleep(150);
        Vis.Step("Verpackung", $"Stecke Linse {lens.Id} in Schutzhülle");
        Thread.Sleep(100);
        Vis.Step("Verpackung", "Setze Linse in Polsterung ein");
        Thread.Sleep(100);
        Vis.Step("Verpackung", "Verschließe mit Stahlbändern");
        Thread.Sleep(100);
        Vis.Step("Verpackung", "Hefte Zollpapiere an");
    }
}