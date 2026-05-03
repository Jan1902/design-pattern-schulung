using LensForge.Shared;

namespace LensForge.Kata04;

public class InvoiceWriter
{
    public string WriteInvoiceLine(Lens lens, CustomerType customerType)
    {
        // Auf der Rechnung soll die Verpackung als Position stehen
        string packagingDescription = customerType switch
        {
            CustomerType.EndCustomer => "Standard-Pappkarton (Endkundenversand)",
            CustomerType.OpticianWholesale => "Holzkiste (Optiker-Großhandel)",
            CustomerType.Laboratory => "Sterilbox (Labor-Versand)",
            _ => throw new NotSupportedException(),
        };

        return $"Linse {lens.Id} | Verpackung: {packagingDescription}";
    }
}
