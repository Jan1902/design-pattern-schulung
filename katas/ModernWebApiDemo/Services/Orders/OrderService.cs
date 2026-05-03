using Microsoft.EntityFrameworkCore;
using ModernWebApiDemo.Data;
using ModernWebApiDemo.Models;
using ModernWebApiDemo.Notifications;
using ModernWebApiDemo.Services.Clock;
using ModernWebApiDemo.Services.Pricing;

namespace ModernWebApiDemo.Services.Orders;

public class OrderService(
    OrderDbContext db,
    IClock clock,
    IEnumerable<IPricingStrategy> pricingStrategies,
    IEnumerable<IOrderEventHandler> eventHandlers) : IOrderService
{
    private readonly OrderDbContext _db = db;
    private readonly IClock _clock = clock;
    private readonly IEnumerable<IPricingStrategy> _pricingStrategies = pricingStrategies;
    private readonly IEnumerable<IOrderEventHandler> _eventHandlers = eventHandlers;

    public async Task<Order> PlaceOrderAsync(PlaceOrderRequest request)
    {
        var customer = await _db.Customers.FindAsync(request.CustomerId)
            ?? throw new InvalidOperationException(
                $"Customer {request.CustomerId} not found");

        var items = new List<OrderItem>();
        foreach (var itemRequest in request.Items)
        {
            var lens = await _db.Lenses.FindAsync(itemRequest.LensId)
                ?? throw new InvalidOperationException(
                    $"Lens {itemRequest.LensId} not found");

            items.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                LensId = lens.Id,
                Lens = lens,
                Quantity = itemRequest.Quantity,
            });
        }

        // Strategy: Wähle die passende Preisberechnung für den Kunden
        var pricing = _pricingStrategies.First(s => s.AppliesTo(customer));
        var totalPrice = pricing.Calculate(items);

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
            Customer = customer,
            Items = items,
            TotalPrice = totalPrice,
            Status = OrderStatus.Placed,
            PlacedAt = _clock.Now,
        };

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        // Observer: Benachrichtige alle Handler
        foreach (var handler in _eventHandlers)
            await handler.OnOrderPlacedAsync(order);

        return order;
    }

    public async Task<Order?> GetOrderAsync(Guid orderId)
    {
        return await _db.Orders
            .Include(o => o.Customer)
            .Include(o => o.Items)
                .ThenInclude(i => i.Lens)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }
}