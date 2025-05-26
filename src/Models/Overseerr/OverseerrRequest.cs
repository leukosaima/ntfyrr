using System.Text.Json.Serialization;

namespace ntfyrr.Models.Overseerr;

public class OverseerrRequest
{
    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = string.Empty;

    [JsonPropertyName("requestedBy_email")]
    public string RequestedByEmail { get; set; } = string.Empty;

    [JsonPropertyName("requestedBy_username")]
    public string RequestedByUsername { get; set; } = string.Empty;

    [JsonPropertyName("requestedBy_avatar")]
    public string RequestedByAvatar { get; set; } = string.Empty;

    [JsonPropertyName("requestedBy_settings_discordId")]
    public string RequestedBySettingsDiscordId { get; set; } = string.Empty;

    [JsonPropertyName("requestedBy_settings_telegramChatId")]
    public string RequestedBySettingsTelegramChatId { get; set; } = string.Empty;
}
