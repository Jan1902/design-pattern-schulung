using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Services.Pricing;

public class StandardPricing : IPricingStrategy
{
    public bool AppliesTo(Customer customer) =>
        customer.Segment == CustomerSegment.Standard;

    public decimal Calculate(IEnumerable<OrderItem> items) =>
        items.Sum(i => i.Lens.BasePrice * i.Quantity);
}
