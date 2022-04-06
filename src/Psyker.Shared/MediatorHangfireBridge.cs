namespace Psyker.Shared;

using System.ComponentModel;

public sealed class MediatorHangfireBridge
{
    private readonly IMediator mediator;

    public MediatorHangfireBridge(IMediator mediator) => this.mediator = mediator;

    public async Task Send(IRequest command) => await mediator.Send(command);

    [DisplayName("{0}")]
    public async Task Send(string jobName, IRequest command) => await mediator.Send(command);
}
