using System.Text.Json.Serialization;

namespace ntfyrr.Models.Maintainerr;

public class MaintainerrNotification
{
    public const string Prefix = "Maintainerr - ";

    [JsonPropertyName("subject")]
    public required string Subject { get; set; }

    [JsonPropertyName("message")]
    public required string Message { get; set; }

    [JsonPropertyName("dayAmount")]
    public string DayAmount { get; set; } = string.Empty;

    [JsonPropertyName("collectionName")]
    public string CollectionName { get; set; } = string.Empty;
}
