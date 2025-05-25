using System.Text.Json.Serialization;
using ntfyrr.Middleware;
using ntfyrr.Services;
using ntfyrr.Models;

DotNetEnv.Env.Load("./Config/.env");
EnvVars.EnsureDefaults();

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Parse("0.0.0.0"), DotNetEnv.Env.GetInt(EnvVars.LISTEN_PORT));
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddScoped<NtfyApiService>();
builder.Services.AddHttpClient<NtfyApiService>();

var secretsPath = "/run/secrets/user-credentials.json";
NtfyUser? credentials = null;
if (File.Exists(secretsPath))
{
    var secretsJson = File.ReadAllText(secretsPath);
    credentials = System.Text.Json.JsonSerializer.Deserialize<NtfyUser>(secretsJson);
    builder.Services.AddSingleton(credentials!);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<RequestLoggingMiddleware>();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Console.WriteLine($"ntfyrr - Configured to send notifications to {DotNetEnv.Env.GetString(EnvVars.NTFY_URL)}/{DotNetEnv.Env.GetString(EnvVars.TOPIC_NAME)}");
Console.WriteLine($"ntfyrr - Configured Overseerr URL: {DotNetEnv.Env.GetString(EnvVars.OVERSEERR_URL, "**NOT SET**")}");

if (credentials is not null)
{
    Console.WriteLine($"ntfyrr - Using defined credentials for user: {credentials.Username}");
}

app.Run();
