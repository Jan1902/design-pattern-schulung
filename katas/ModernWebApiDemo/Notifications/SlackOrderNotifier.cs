using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Notifications;

public class SlackOrderNotifier(ILogger<SlackOrderNotifier> logger) : IOrderEventHandler
{
    private readonly ILogger<SlackOrderNotifier> _logger = logger;

    public Task OnOrderPlacedAsync(Order order)
    {
        _logger.LogInformation(
            "Slack-Notification: Neue Bestellung {OrderId} über {Total:C}",
            order.Id, order.TotalPrice);
        return Task.CompletedTask;
    }
}
