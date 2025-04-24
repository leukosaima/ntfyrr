using System.Net.Mime;
using System.Text;
using ntfyrr.Models;

namespace ntfyrr.Services;

public class NtfyApiService
{
    private readonly HttpClient _httpClient;

    public NtfyApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Sends data to the ntfy.sh API.
    /// https://docs.ntfy.sh/publish/
    /// </summary>
    public async Task<bool> SendDataAsync(NtfyModel data)
    {
        var content = new StringContent(data.Message, Encoding.UTF8, MediaTypeNames.Text.Plain);
        content.Headers.Add("X-Title", data.Title);
        content.Headers.Add("X-Priority", data.Priority.ToString());
        content.Headers.Add("X-Tag", data.Tags);

        var response = await _httpClient.PostAsync($"{DotNetEnv.Env.GetString("NTFY_URL", "https://ntfy.sh")}/{DotNetEnv.Env.GetString("TOPIC_NAME")}", content);

        try
        {
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }

        return false;
    }
}
