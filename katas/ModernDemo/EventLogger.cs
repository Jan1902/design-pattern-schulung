using Microsoft.Extensions.Logging;

namespace ModernDemo;

public class EventLogger
{
    private readonly ILogger<EventLogger> _log;

    public EventLogger(LensFactory factory, ILogger<EventLogger> log)
    {
        _log = log;
        factory.Produced += OnProduced;
    }

    private void OnProduced(object? sender, ProductionEventArgs e)
    {
        _log.LogInformation("[EventLogger] Received production event: {Item}", e.Item);
    }
}
