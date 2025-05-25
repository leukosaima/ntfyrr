namespace ntfyrr.Models;

public static class OverseerrToNtfy
{
    public static NtfyModel Convert(OverseerrModel overseerrModel)
    {
        var title = $"{OverseerrModel.Prefix}{overseerrModel.GetNotificationTypeString()}";

        var moreInfo = string.Empty;
        if (overseerrModel.Request is not null)
        {
            moreInfo = $"""

                Requester: {overseerrModel.Request.RequestedByUsername}
                """;
        }

        if (overseerrModel.Issue is not null)
        {
            moreInfo += $"""

                Issue status: {overseerrModel.Issue.IssueStatus}
                Reported by: {overseerrModel.Issue.ReportedByUsername}
                """;
        }

        var message = $"""
            {overseerrModel.Event}

            {overseerrModel.Subject}
            {moreInfo}

            {overseerrModel.Message}
            """;

        var ntfyModel = new NtfyModel
        {
            Title = title,
            Message = message,
            Attach = overseerrModel.Image,
            Tags = overseerrModel.GetNotificationTypeTags(),
            Icon = overseerrModel.GetNotificationTypeIcon(),
            Click = string.IsNullOrWhiteSpace(DotNetEnv.Env.GetString(EnvVars.OVERSEERR_URL)) ? string.Empty : $"{DotNetEnv.Env.GetString(EnvVars.OVERSEERR_URL)}/{overseerrModel.Media?.MediaType}/{overseerrModel.Media?.TmdbId}"
        };

        return ntfyModel;        
    }
}
