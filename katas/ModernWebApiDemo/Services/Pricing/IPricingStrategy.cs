using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Services.Pricing;

public interface IPricingStrategy
{
    bool AppliesTo(Customer customer);
    decimal Calculate(IEnumerable<OrderItem> items);
}
