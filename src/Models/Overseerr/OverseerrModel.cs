using System.Text.Json.Serialization;

namespace ntfyrr.Models;

/// <summary>
/// Model for the default Overseerr webhook payload.
/// https://docs.overseerr.dev/using-overseerr/notifications/webhooks#template-variables
/// </summary>
public class OverseerrModel
{
    public const string Prefix = "Overseerr - ";

    /// <summary>
    /// The notification subject (typically the media title)
    /// </summary>
    [JsonPropertyName("subject")]
    public required string Subject { get; set; }

    /// <summary>
    /// The notification message body (the media overview/synopsis for request notifications;
    /// the issue description for issue notificatons)
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

    /// <summary>
    /// The type of notification
    /// https://github.com/sct/overseerr/blob/develop/server/lib/notifications/index.ts
    /// </summary>
    [JsonPropertyName("notification_type")]
    public required OverseerrNotificationType NotificationType { get; set; }

    /// <summary>
    /// A friendly description of the notification event
    /// </summary>
    [JsonPropertyName("event")]
    public required string Event { get; set; }

    /// <summary>
    /// The notification image (typically the media poster)
    /// </summary>
    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;

    public string GetNotificationTypeString()
    {
        return NotificationType switch
        {
            OverseerrNotificationType.NONE => "None",
            OverseerrNotificationType.MEDIA_PENDING => "Media Pending",
            OverseerrNotificationType.MEDIA_APPROVED => "Media Approved",
            OverseerrNotificationType.MEDIA_AVAILABLE => "Media Available",
            OverseerrNotificationType.MEDIA_FAILED => "Media Failed",
            OverseerrNotificationType.TEST_NOTIFICATION => "Test Notification",
            OverseerrNotificationType.MEDIA_DECLINED => "Media Declined",
            OverseerrNotificationType.MEDIA_AUTO_APPROVED => "Media Auto Approved",
            OverseerrNotificationType.ISSUE_CREATED => "Issue Created",
            OverseerrNotificationType.ISSUE_COMMENT => "Issue Comment",
            OverseerrNotificationType.ISSUE_RESOLVED => "Issue Resolved",
            OverseerrNotificationType.ISSUE_REOPENED => "Issue Reopened",
            OverseerrNotificationType.MEDIA_AUTO_REQUESTED => "Media Auto Requested",
            _ => throw new ArgumentOutOfRangeException(nameof(NotificationType), NotificationType, nameof(GetNotificationTypeString))
        };
    }
}
