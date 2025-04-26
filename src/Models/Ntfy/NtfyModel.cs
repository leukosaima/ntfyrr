namespace ntfyrr.Models;

public class NtfyModel
{
    public string Attach { get; init; } = string.Empty;

    public string Icon { get; init; } = string.Empty;

    public required string Message { get; init; }

    public NtfyPriority Priority { get; init; } = NtfyPriority.Default;

    // https://docs.ntfy.sh/emojis/
    public string Tags { get; init; } = string.Empty;

    public required string Title { get; init; }
}
