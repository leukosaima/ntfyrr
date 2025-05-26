using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using ntfyrr.Models;

namespace ntfyrr.Services;

public class NtfyApiService
{
    private readonly HttpClient _httpClient;
    private readonly NtfyUser? _ntfyUser;

    public NtfyApiService(HttpClient httpClient, NtfyUser? ntfyUser = null)
    {
        _httpClient = httpClient;
        _ntfyUser = ntfyUser;
    }

    /// <summary>
    /// Sends data to the ntfy.sh API.
    /// https://docs.ntfy.sh/publish/
    /// </summary>
    public async Task<bool> SendDataAsync(NtfyModel model, string topicName)
    {
        var content = new StringContent(model.Message, Encoding.UTF8, MediaTypeNames.Text.Plain);
        content.Headers.Add("X-Attach", model.Attach);
        content.Headers.Add("X-Icon", model.Icon);
        content.Headers.Add("X-Markdown", "true");
        content.Headers.Add("X-Priority", model.Priority.ToString());
        content.Headers.Add("X-Tags", model.Tags);
        content.Headers.Add("X-Title", model.Title);
        content.Headers.Add("X-Click", model.Click);

        // Add authentication if credentials are available
        if (_ntfyUser != null)
        {
            AuthenticationHeaderValue authHeader;
            if (!string.IsNullOrWhiteSpace(_ntfyUser.Token))
            {
                authHeader = new AuthenticationHeaderValue("Bearer", _ntfyUser.Token);
            }
            else
            {
                var basicAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_ntfyUser.Username}:{_ntfyUser.Password}"));
                authHeader = new AuthenticationHeaderValue("Basic", basicAuth);
            }
            _httpClient.DefaultRequestHeaders.Authorization = authHeader;
        }

        var response = await _httpClient.PostAsync($"{DotNetEnv.Env.GetString(EnvVars.NTFY_URL)}/{topicName}", content);

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
