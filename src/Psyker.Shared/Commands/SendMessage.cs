namespace Psyker.Shared.Commands;

public sealed record SendMessage : IRequest
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Payload { get; init; } = string.Empty;
}
