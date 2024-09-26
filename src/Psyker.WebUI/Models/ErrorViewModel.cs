namespace Psyker.WebUI.Models;

public sealed class ErrorViewModel
{
    public string? RequestId { get; init; } = default;

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
