using System.Text.Json.Serialization;

namespace ntfyrr.Models.Overseerr;

public class OverseerrComment
{
    [JsonPropertyName("comment_message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("commentedBy_email")]
    public string CommentedByEmail { get; set; } = string.Empty;

    [JsonPropertyName("commentedBy_username")]
    public string CommentedByUsername { get; set; } = string.Empty;

    [JsonPropertyName("commentedBy_avatar")]
    public string CommentedByAvatar { get; set; } = string.Empty;

    [JsonPropertyName("commentedBy_settings_discordId")]
    public string CommentedByDiscordId { get; set; } = string.Empty;

    [JsonPropertyName("commentedBy_settings_telegramChatId")]
    public string CommentedByTelegramChatId { get; set; } = string.Empty;
} 