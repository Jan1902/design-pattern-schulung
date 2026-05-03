namespace ModernWebApiDemo.Models;

public enum OrderStatus
{
    Placed,
    InProduction,
    Shipped,
    Cancelled,
}

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<OrderItem> Items { get; set; } = new();
    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime PlacedAt { get; set; }
}

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid LensId { get; set; }
    public Lens Lens { get; set; } = null!;
    public int Quantity { get; set; }
}
