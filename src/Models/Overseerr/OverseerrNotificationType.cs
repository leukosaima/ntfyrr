namespace ntfyrr.Models.Overseerr;

public enum OverseerrNotificationType
{
    NONE = 0,
    MEDIA_PENDING = 2,
    MEDIA_APPROVED = 4,
    MEDIA_AVAILABLE = 8,
    MEDIA_FAILED = 16,
    TEST_NOTIFICATION = 32,
    MEDIA_DECLINED = 64,
    MEDIA_AUTO_APPROVED = 128,
    ISSUE_CREATED = 256,
    ISSUE_COMMENT = 512,
    ISSUE_RESOLVED = 1024,
    ISSUE_REOPENED = 2048,
    MEDIA_AUTO_REQUESTED = 4096,
}
