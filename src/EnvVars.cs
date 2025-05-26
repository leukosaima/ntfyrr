public static class EnvVars
{
    public static string NTFY_URL = nameof(NTFY_URL);

    public static string LISTEN_PORT = nameof(LISTEN_PORT);

    public static string OVERSEERR_TOPIC = nameof(OVERSEERR_TOPIC);

    public static string OVERSEERR_URL = nameof(OVERSEERR_URL);

    public static string MAINTAINERR_TOPIC = nameof(MAINTAINERR_TOPIC);

    public static string MAINTAINERR_URL = nameof(MAINTAINERR_URL);

    public static void EnsureDefaults()
    {
        Environment.SetEnvironmentVariable(OVERSEERR_TOPIC, DotNetEnv.Env.GetString(OVERSEERR_TOPIC, "overseerr"));
        Environment.SetEnvironmentVariable(MAINTAINERR_TOPIC, DotNetEnv.Env.GetString(MAINTAINERR_TOPIC, "maintainerr"));
        Environment.SetEnvironmentVariable(LISTEN_PORT, DotNetEnv.Env.GetString(LISTEN_PORT, "5000"));
        Environment.SetEnvironmentVariable(NTFY_URL, DotNetEnv.Env.GetString(NTFY_URL, "https://ntfy.sh"));
    }

    public static void WriteToConsole()
    {
        Console.WriteLine($"{NTFY_URL} - Configured to send notifications to {DotNetEnv.Env.GetString(NTFY_URL)}");
        Console.WriteLine($"{OVERSEERR_TOPIC} - Configured Overseerr topic: {DotNetEnv.Env.GetString(OVERSEERR_TOPIC)}");
        Console.WriteLine($"{OVERSEERR_URL} - Configured Overseerr URL: {DotNetEnv.Env.GetString(OVERSEERR_URL, "**NOT SET**")}");
        Console.WriteLine($"{MAINTAINERR_TOPIC} - Configured Maintainerr topic: {DotNetEnv.Env.GetString(MAINTAINERR_TOPIC)}");
        Console.WriteLine($"{MAINTAINERR_URL} - Configured Maintainerr URL: {DotNetEnv.Env.GetString(MAINTAINERR_URL, "**NOT SET**")}");
    }
}