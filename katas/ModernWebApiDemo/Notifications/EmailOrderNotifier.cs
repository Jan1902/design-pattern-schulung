using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Notifications;

public class EmailOrderNotifier(ILogger<EmailOrderNotifier> logger) : IOrderEventHandler
{
    private readonly ILogger<EmailOrderNotifier> _logger = logger;

    public Task OnOrderPlacedAsync(Order order)
    {
        _logger.LogInformation(
            "Sende Bestellbestätigung an {Email} für Order {OrderId}",
            order.Customer.Email, order.Id);
        return Task.CompletedTask;
    }
}
