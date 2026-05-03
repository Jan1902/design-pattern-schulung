using Microsoft.Extensions.Logging;

namespace ModernDemo;

public class ProductionEventArgs(string item) : EventArgs
{
    public string Item { get; } = item;
}

// Observer publisher
public class LensFactory(IHttpClientFactory httpFactory, ILogger<LensFactory> log)
{
    public event EventHandler<ProductionEventArgs>? Produced;

    private readonly IHttpClientFactory _httpFactory = httpFactory;
    private readonly ILogger<LensFactory> _log = log;

    public async Task ProduceAsync()
    {
        _log.LogInformation("[LensFactory] Producing...");

        // Create a client from the factory and perform a simple request (demo only)
        var client = _httpFactory.CreateClient("demo");
        try
        {
            var resp = await client.GetAsync("/");
            _log.LogInformation("[LensFactory] HTTP GET / returned {StatusCode}", resp.StatusCode);
        }
        catch (Exception ex)
        {
            _log.LogWarning(ex, "[LensFactory] HTTP request failed (this is expected in demos without network)");
        }

        await Task.Delay(250);
        Produced?.Invoke(this, new ProductionEventArgs($"Lens #{DateTime.UtcNow.Ticks}"));
    }
}
