using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Notifications;

public class AuditLogNotifier(ILogger<AuditLogNotifier> logger) : IOrderEventHandler
{
    private readonly ILogger<AuditLogNotifier> _logger = logger;

    public Task OnOrderPlacedAsync(Order order)
    {
        _logger.LogInformation(
            "AUDIT: Order {OrderId} placed by Customer {CustomerId} at {Time}",
            order.Id, order.CustomerId, order.PlacedAt);
        return Task.CompletedTask;
    }
}