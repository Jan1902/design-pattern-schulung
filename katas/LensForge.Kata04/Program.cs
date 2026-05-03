using LensForge.Kata04;
using LensForge.Shared;

Vis.Header("LensForge — Versand-Modul Demo");

// TODO: Diese drei Klassen brauchen jetzt eine gemeinsame Lösung.
//       Welche Konstruktor-Parameter haben sie nach eurem Refactoring?
var preparation = new ShippingPreparation(/* ... */);
var orderProcessor = new OrderProcessor(/* ... */);
var invoiceWriter = new InvoiceWriter(/* ... */);

var orders = new[]
{
    (new Lens("L-001", LensType.Standard, 52), CustomerType.EndCustomer),
    (new Lens("L-002", LensType.HighIndex, 54), CustomerType.OpticianWholesale),
    (new Lens("L-003", LensType.Photochromic, 50), CustomerType.Laboratory),

    // Diese zwei sind aktuell auskommentiert. Nach eurem Refactor sollen sie funktionieren:
    // (new Lens("L-004", LensType.Standard, 52),  CustomerType.ExpressSecure),
    // (new Lens("L-005", LensType.HighIndex, 54), CustomerType.WholesaleExport),
};

foreach (var (lens, customerType) in orders)
{
    Vis.Separator();
    Vis.Lens(lens);
    Vis.Step("Auftrag", $"Kundentyp: {customerType}");

    orderProcessor.ProcessOrder(lens, customerType);
    var shipment = preparation.PrepareShipment(lens, customerType);
    var invoiceLine = invoiceWriter.WriteInvoiceLine(lens, customerType);

    Vis.Step("Versand", $"Verpackt: {shipment.PackagingType} → {shipment.ShippingLabel}");
    Vis.Step("Rechnung", invoiceLine);
}

Vis.Step("Demo", "Alle Aufträge verarbeitet.");