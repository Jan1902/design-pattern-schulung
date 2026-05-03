using LensForge.Shared;

namespace LensForge.Kata04.Tests;

public class ShippingTests
{
    [Fact]
    public void Preparation_ProducesCorrectPackaging_PerCustomerType()
    {
        var preparation = BuildPreparation();
        var lens = new Lens("L-T01", LensType.Standard, 52);

        Assert.Equal("Pappkarton",
            preparation.PrepareShipment(lens, CustomerType.EndCustomer).PackagingType);
        Assert.Equal("Holzkiste",
            preparation.PrepareShipment(lens, CustomerType.OpticianWholesale).PackagingType);
        Assert.Equal("Sterilbox",
            preparation.PrepareShipment(lens, CustomerType.Laboratory).PackagingType);
    }

    [Fact]
    public void Preparation_AndOrderProcessor_AgreeOnPackaging()
    {
        // Wenn beide dieselbe Quelle für die Verpackungs-Entscheidung nutzen,
        // müssen sie übereinstimmen
        var preparation = BuildPreparation();
        var orderProcessor = BuildOrderProcessor();

        var lens = new Lens("L-T02", LensType.HighIndex, 54);
        var shipment = preparation.PrepareShipment(lens, CustomerType.OpticianWholesale);
        var order = orderProcessor.ProcessOrder(lens, CustomerType.OpticianWholesale);

        Assert.Equal(shipment.PackagingType, order.PackagingType);
    }

    [Fact]
    public void Preparation_HandlesNewCustomerTypes()
    {
        var preparation = BuildPreparation();
        var lens = new Lens("L-T03", LensType.Standard, 52);

        Assert.Equal("Sicherheits-Box",
            preparation.PrepareShipment(lens, CustomerType.ExpressSecure).PackagingType);
        Assert.Equal("Verstärkte Holzkiste",
            preparation.PrepareShipment(lens, CustomerType.WholesaleExport).PackagingType);
    }

    // TODO: Diese Methoden müsst ihr füllen.
    //       Sie sollen ShippingPreparation bzw. OrderProcessor liefern,
    //       die alle Kundentypen verarbeiten können (auch die neuen).

    private ShippingPreparation BuildPreparation()
        => throw new NotImplementedException();

    private OrderProcessor BuildOrderProcessor()
        => throw new NotImplementedException();
}