using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Demos;

public class OrderBuilder
{
    private Guid _customerId;
    private DateTime _orderDate;
    private readonly List<OrderItem> _items = [];

    public static OrderBuilder Create()
    {
        return new OrderBuilder();
    }

    public OrderBuilder SetCustomerId(Guid customerId)
    {
        _customerId = customerId;
        return this;
    }

    public OrderBuilder SetOrderDate(DateTime orderDate)
    {
        _orderDate = orderDate;
        return this;
    }

    public OrderBuilder AddItem(Guid productId, int quantity)
    {
        _items.Add(new OrderItem { LensId = productId, Quantity = quantity });
        return this;
    }

    public Order Build()
    {
        return new Order
        {
            CustomerId = _customerId,
            PlacedAt = _orderDate,
            TotalPrice = _items.Sum(i => i.Quantity * 10), // Assume each item costs $10 for simplicity
            Items = _items,
            Id = Guid.NewGuid(),
        };
    }
}

public class DemoBuilder
{
    public DemoBuilder()
    {
        var order = OrderBuilder.Create()
            .SetCustomerId(Guid.NewGuid())
            .SetOrderDate(DateTime.UtcNow)
            .AddItem(Guid.NewGuid(), 2)
            .AddItem(Guid.NewGuid(), 3)
            .Build();

        Console.WriteLine(order);
    }
}