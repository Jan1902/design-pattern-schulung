using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Notifications;

public interface IOrderEventHandler
{
    Task OnOrderPlacedAsync(Order order);
}
