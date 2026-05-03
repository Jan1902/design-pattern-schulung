using LensForge.Shared;

namespace LensForge.Kata04.Solution;

internal class OrderProcessor
{
    private readonly PackagingFactory _factory;

    public OrderProcessor(PackagingFactory factory)
    {
        _factory = factory;
    }

    public OrderConfirmation ProcessOrder(Lens lens, CustomerType customerType)
    {
        var packaging = _factory.CreateFor(customerType);

        Vis.Step("Auftrag",
            $"Bestätigung für {lens.Id}: Verpackung {packaging.PackagingType}, " +
            $"Kosten +{packaging.Cost:C}");

        return new OrderConfirmation(lens, packaging.PackagingType, packaging.Cost);
    }
}