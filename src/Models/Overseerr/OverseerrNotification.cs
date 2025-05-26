using System.Text.Json.Serialization;

namespace ntfyrr.Models.Overseerr;

/// <summary>
/// Model for the default Overseerr webhook payload.
/// https://docs.overseerr.dev/using-overseerr/notifications/webhooks#template-variables
/// </summary>
public class OverseerrNotification
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

    [JsonPropertyName("media")]
    public OverseerrMedia? Media { get; set; } = null;

    [JsonPropertyName("request")]
    public OverseerrRequest? Request { get; set; } = null;

    [JsonPropertyName("issue")]
    public OverseerrIssue? Issue { get; set; } = null;

    [JsonPropertyName("comment")]
    public OverseerrComment? Comment { get; set; } = null;

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

    public string GetNotificationTypeTags()
    {
        return NotificationType switch
        {
            //OverseerrNotificationType.NONE
            OverseerrNotificationType.MEDIA_PENDING => "mag",
            OverseerrNotificationType.MEDIA_APPROVED => "+1",
            OverseerrNotificationType.MEDIA_AVAILABLE => "popcorn",
            OverseerrNotificationType.MEDIA_FAILED => "x",
            OverseerrNotificationType.TEST_NOTIFICATION => "test_tube",
            OverseerrNotificationType.MEDIA_DECLINED => "-1",
            OverseerrNotificationType.MEDIA_AUTO_APPROVED => "white_check_mark",
            OverseerrNotificationType.ISSUE_CREATED => "thinking",
            OverseerrNotificationType.ISSUE_COMMENT => "speech_balloon",
            OverseerrNotificationType.ISSUE_RESOLVED => "ok_hand",
            OverseerrNotificationType.ISSUE_REOPENED => "construction",
            OverseerrNotificationType.MEDIA_AUTO_REQUESTED => "robot",
            _ => string.Empty
        };
    }

    public string GetNotificationTypeIcon()
    {
        if (Issue is not null)
        {
            return NotificationType switch
            {
                OverseerrNotificationType.ISSUE_CREATED or
                OverseerrNotificationType.ISSUE_COMMENT or
                OverseerrNotificationType.ISSUE_RESOLVED or
                OverseerrNotificationType.ISSUE_REOPENED => Issue.ReportedByAvatar,
                _ => string.Empty
            };
        }
        
        if (Request is not null)
        {
            return NotificationType switch
            {
                OverseerrNotificationType.MEDIA_PENDING or
                OverseerrNotificationType.MEDIA_APPROVED or
                OverseerrNotificationType.MEDIA_AVAILABLE or
                OverseerrNotificationType.MEDIA_FAILED or
                OverseerrNotificationType.MEDIA_DECLINED or
                OverseerrNotificationType.MEDIA_AUTO_REQUESTED or
                OverseerrNotificationType.MEDIA_AUTO_APPROVED => Request.RequestedByAvatar,
                _ => string.Empty
            };
        }

        return string.Empty;
    }
}
