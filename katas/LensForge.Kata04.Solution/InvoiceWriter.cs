using LensForge.Shared;

namespace LensForge.Kata04.Solution;

internal class InvoiceWriter
{
    private readonly PackagingFactory _factory;

    public InvoiceWriter(PackagingFactory factory)
    {
        _factory = factory;
    }

    public string WriteInvoiceLine(Lens lens, CustomerType customerType)
    {
        var packaging = _factory.CreateFor(customerType);
        return $"Linse {lens.Id} | Verpackung: {packaging.PackagingType} ({packaging.ShippingLabel})";
    }
}