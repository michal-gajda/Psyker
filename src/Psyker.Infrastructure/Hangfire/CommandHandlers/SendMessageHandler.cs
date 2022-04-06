namespace Psyker.Infrastructure.Hangfire.CommandHandlers;

using Psyker.Shared.Commands;

internal sealed class SendMessageHandler : IRequestHandler<SendMessage>
{
    private readonly ILogger<SendMessageHandler> logger;

    public SendMessageHandler(ILogger<SendMessageHandler> logger) => this.logger = logger;

    public async Task<Unit> Handle(SendMessage request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("{Id}: {Payload}", request.Id, request.Payload);
        return await Task.FromResult(Unit.Value);
    }
}
