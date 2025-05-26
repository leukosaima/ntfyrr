namespace ntfyrr.Models.Maintainerr;

public static class MaintainerrToNtfy
{
    public static NtfyModel Convert(MaintainerrNotification maintainerrModel)
    {
        var title = $"{MaintainerrNotification.Prefix}{maintainerrModel.Subject}";

        var moreInfo = string.Empty;
        if (!string.IsNullOrWhiteSpace(maintainerrModel.CollectionName))
        {
            moreInfo = $"""

                Collection: {maintainerrModel.CollectionName}
                """;
        }

        if (!string.IsNullOrWhiteSpace(maintainerrModel.DayAmount))
        {
            moreInfo += $"""

                Remaining days: {maintainerrModel.DayAmount}
                """;
        }

        var message = $"""
            {maintainerrModel.Message}
            {moreInfo}
            """;

        var ntfyModel = new NtfyModel
        {
            Title = title,
            Message = message,
            Click = $"{DotNetEnv.Env.GetString(EnvVars.MAINTAINERR_URL)}"
        };

        return ntfyModel;        
    }
}
