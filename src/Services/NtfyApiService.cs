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
    public async Task<bool> SendDataAsync(NtfyModel model)
    {
        var content = new StringContent(model.Message, Encoding.UTF8, MediaTypeNames.Text.Plain);
        content.Headers.Add("X-Attach", model.Attach);
        content.Headers.Add("X-Icon", model.Icon);
        content.Headers.Add("X-Markdown", "true");
        content.Headers.Add("X-Priority", model.Priority.ToString());
        content.Headers.Add("X-Tags", model.Tags);
        content.Headers.Add("X-Title", model.Title);

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
