using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Services.Orders;

public record PlaceOrderRequest(Guid CustomerId, List<OrderItemRequest> Items);
public record OrderItemRequest(Guid LensId, int Quantity);

public interface IOrderService
{
    Task<Order> PlaceOrderAsync(PlaceOrderRequest request);
    Task<Order?> GetOrderAsync(Guid orderId);
}