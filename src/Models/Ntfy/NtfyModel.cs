namespace ntfyrr.Models;

public class NtfyModel
{
    public required string Title { get; set; }

    public required string Message { get; set; }

    public NtfyPriority Priority { get; set; } = NtfyPriority.Default;

    // https://docs.ntfy.sh/emojis/
    public string Tags { get; set; } = string.Empty;
}
