using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Services.Pricing;

public class PremiumCustomerPricing : IPricingStrategy
{
    public bool AppliesTo(Customer customer) =>
        customer.Segment == CustomerSegment.Premium;

    public decimal Calculate(IEnumerable<OrderItem> items)
    {
        // VIP-Kunden bekommen 10% Rabatt + freie Express-Lieferung
        var subtotal = items.Sum(i => i.Lens.BasePrice * i.Quantity);
        return subtotal * 0.90m;
    }
}