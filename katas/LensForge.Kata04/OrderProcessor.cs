using LensForge.Shared;

namespace LensForge.Kata04;

public class OrderProcessor
{
    public OrderConfirmation ProcessOrder(Lens lens, CustomerType customerType)
    {
        // Wir müssen schon hier wissen, welche Verpackung der Kunde bekommt,
        // um die Versandkosten zu berechnen
        string packagingType;
        decimal packagingCost;

        if (customerType == CustomerType.EndCustomer)
        {
            packagingType = "Pappkarton";
            packagingCost = 2.50m;
        }
        else if (customerType == CustomerType.OpticianWholesale)
        {
            packagingType = "Holzkiste";
            packagingCost = 8.00m;
        }
        else if (customerType == CustomerType.Laboratory)
        {
            packagingType = "Sterilbox";
            packagingCost = 15.00m;
        }
        else
        {
            throw new NotSupportedException($"Auftrag für {customerType} unbekannt");
        }

        Vis.Step("Auftrag", $"Bestätigung für {lens.Id}: Verpackung {packagingType}, +{packagingCost:C}");

        return new OrderConfirmation(lens, packagingType, packagingCost);
    }
}

public record OrderConfirmation(
    Lens Lens,
    string PackagingType,
    decimal PackagingCost);