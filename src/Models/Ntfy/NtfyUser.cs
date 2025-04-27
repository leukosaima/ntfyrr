using System.Text.Json.Serialization;

namespace ntfyrr.Models;

public class NtfyUser
{
    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [JsonPropertyName("password")]
    public required string Password { get; set; }
}
