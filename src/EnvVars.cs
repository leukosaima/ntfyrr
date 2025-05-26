public static class EnvVars
{
    public static string TOPIC_NAME = nameof(TOPIC_NAME);

    public static string NTFY_URL = nameof(NTFY_URL);

    public static string LISTEN_PORT = nameof(LISTEN_PORT);

    public static string OVERSEERR_URL = nameof(OVERSEERR_URL);

    public static string MAINTAINERR_URL = nameof(MAINTAINERR_URL);

    public static void EnsureDefaults()
    {
        if (string.IsNullOrWhiteSpace(DotNetEnv.Env.GetString(TOPIC_NAME)))
        {
            throw new ArgumentException($"{TOPIC_NAME} environment variable must be defined.");
        }

        Environment.SetEnvironmentVariable(LISTEN_PORT, DotNetEnv.Env.GetString(LISTEN_PORT, "5000"));
        Environment.SetEnvironmentVariable(NTFY_URL, DotNetEnv.Env.GetString(NTFY_URL, "https://ntfy.sh"));
    }
}