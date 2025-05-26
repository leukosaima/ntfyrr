using System.Text.Json.Serialization;

namespace ntfyrr.Models.Overseerr;

public class OverseerrIssue
{
    [JsonPropertyName("issue_id")]
    public int IssueId { get; set; }

    [JsonPropertyName("issue_type")]
    public string IssueType { get; set; } = string.Empty;

    [JsonPropertyName("issue_status")]
    public string IssueStatus { get; set; } = string.Empty;

    [JsonPropertyName("reportedBy_email")]
    public string ReportedByEmail { get; set; } = string.Empty;

    [JsonPropertyName("reportedBy_username")]
    public string ReportedByUsername { get; set; } = string.Empty;

    [JsonPropertyName("reportedBy_avatar")]
    public string ReportedByAvatar { get; set; } = string.Empty;

    [JsonPropertyName("reportedBy_settings_discordId")]
    public string ReportedByDiscordId { get; set; } = string.Empty;

    [JsonPropertyName("reportedBy_settings_telegramChatId")]
    public string ReportedByTelegramChatId { get; set; } = string.Empty;
} 