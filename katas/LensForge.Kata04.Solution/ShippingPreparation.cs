using LensForge.Shared;

namespace LensForge.Kata04.Solution;

internal class ShippingPreparation
{
    private readonly PackagingFactory _factory;

    public ShippingPreparation(PackagingFactory factory)
    {
        _factory = factory;
    }

    public PackagedShipment PrepareShipment(Lens lens, CustomerType customerType)
    {
        Vis.Step("Versand", $"Bereite Versand für {lens.Id} vor");

        var packaging = _factory.CreateFor(customerType);
        packaging.PackLens(lens);

        return new PackagedShipment(lens, packaging.PackagingType, packaging.ShippingLabel);
    }
}