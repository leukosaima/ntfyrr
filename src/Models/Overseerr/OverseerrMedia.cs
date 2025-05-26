using System.Text.Json.Serialization;

namespace ntfyrr.Models.Overseerr;

public class OverseerrMedia
{
    [JsonPropertyName("media_type")]
    public string MediaType { get; set; } = string.Empty;

    [JsonPropertyName("tmdbId")]
    public string TmdbId { get; set; } = string.Empty;

    [JsonPropertyName("tvdbId")]
    public string TvdbId { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("status4k")]
    public string Status4k { get; set; } = string.Empty;
}
