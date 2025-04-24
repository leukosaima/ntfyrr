namespace ntfyrr.Models;

public static class OverseerrToNtfy
{
    public static NtfyModel Convert(OverseerrModel overseerrModel)
    {
        var title = $"{OverseerrModel.Prefix}{overseerrModel.GetNotificationTypeString()}";

        var message = $"""
            {overseerrModel.Event}

            {overseerrModel.Subject}

            {overseerrModel.Message}
            """;

        return new NtfyModel
        {
            Title = title,
            Message = message,
        };
    }
}
