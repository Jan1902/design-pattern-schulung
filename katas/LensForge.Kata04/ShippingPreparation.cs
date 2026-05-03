using LensForge.Shared;

namespace LensForge.Kata04;

public class ShippingPreparation
{
    public PackagedShipment PrepareShipment(Lens lens, CustomerType customerType)
    {
        Vis.Step("Versand", $"Bereite Versand für {lens.Id} vor");

        IPackaging packaging;
        if (customerType == CustomerType.EndCustomer)
            packaging = new PappkartonPackaging();
        else if (customerType == CustomerType.OpticianWholesale)
            packaging = new HolzkistePackaging();
        else if (customerType == CustomerType.Laboratory)
            packaging = new SterilboxPackaging();
        else
            throw new NotSupportedException($"Versand für {customerType} unbekannt");

        packaging.PackLens(lens);
        return new PackagedShipment(lens, packaging.PackagingType, packaging.ShippingLabel);
    }
}

public record PackagedShipment(Lens Lens, string PackagingType, string ShippingLabel);