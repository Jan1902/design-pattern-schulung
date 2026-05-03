using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Services.Pricing;

public class BulkDiscountPricing : IPricingStrategy
{
    public bool AppliesTo(Customer customer) =>
        customer.Segment == CustomerSegment.Bulk;

    public decimal Calculate(IEnumerable<OrderItem> items)
    {
        // 15% Rabatt auf den Gesamtpreis für Großhändler
        var subtotal = items.Sum(i => i.Lens.BasePrice * i.Quantity);
        return subtotal * 0.85m;
    }
}
