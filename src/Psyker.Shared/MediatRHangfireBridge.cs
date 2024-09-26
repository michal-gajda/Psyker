namespace Psyker.Shared;

using System.ComponentModel;

public sealed class MediatRHangfireBridge
{
    private readonly IMediator mediator;

    public MediatRHangfireBridge(IMediator mediator)
        => this.mediator = mediator;

    public async Task Send(IRequest command)
        => await mediator.Send(command);

    [DisplayName("{0}")]
    public async Task Send(string jobName, IRequest command)
        => await mediator.Send(command);
}
