using MediatR;
using Microsoft.Extensions.Logging;

namespace ModernDemo;

public record PingCommand(string Message) : IRequest<Unit>;

public class PingHandler : IRequestHandler<PingCommand, Unit>
{
    private readonly ILogger<PingHandler> _log;

    public PingHandler(ILogger<PingHandler> log) => _log = log;

    public Task<Unit> Handle(PingCommand request, CancellationToken cancellationToken)
    {
        _log.LogInformation("[PingHandler] {Message}", request.Message);
        return Task.FromResult(Unit.Value);
    }
}
