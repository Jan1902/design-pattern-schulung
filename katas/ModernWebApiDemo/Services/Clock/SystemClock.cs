namespace ModernWebApiDemo.Services.Clock;

public class SystemClock : IClock
{
    public DateTime Now => DateTime.UtcNow;
}