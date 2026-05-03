using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ModernWebApiDemo.Filters;

public class ExecutionTimingFilter(ILogger<ExecutionTimingFilter> logger) : IActionFilter
{
    private readonly ILogger<ExecutionTimingFilter> _logger = logger;
    private Stopwatch _stopwatch = new();

    // Template Method: Wird vor jeder Action aufgerufen.
    // Du implementierst nur die Hooks, der Lifecycle ist vorgegeben.
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Restart();
    }

    // Template Method: Wird nach jeder Action aufgerufen.
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
        _logger.LogInformation(
            "Action {Action} took {ElapsedMs}ms",
            context.ActionDescriptor.DisplayName,
            _stopwatch.ElapsedMilliseconds);
    }
}