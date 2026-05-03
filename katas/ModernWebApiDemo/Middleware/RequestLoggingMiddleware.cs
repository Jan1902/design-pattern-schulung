using System.Diagnostics;

namespace ModernWebApiDemo.Middleware;

public class RequestLoggingMiddleware(
    RequestDelegate next,
    ILogger<RequestLoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestLoggingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation(
            "→ {Method} {Path}",
            context.Request.Method,
            context.Request.Path);

        var stopwatch = Stopwatch.StartNew();

        // Hier wird die Kette weitergereicht. Wer das nicht tut,
        // bricht die Pipeline ab.
        await _next(context);

        stopwatch.Stop();

        _logger.LogInformation(
            "← {StatusCode} ({ElapsedMs}ms)",
            context.Response.StatusCode,
            stopwatch.ElapsedMilliseconds);
    }
}
