using Microsoft.AspNetCore.Mvc;
using ntfyrr.Models.Overseerr;
using ntfyrr.Services;

namespace ntfyrr.Controllers.Overseerr;

[ApiController]
[Route("[controller]")]
public class OverseerrController : ControllerBase
{
    private readonly NtfyApiService _ntfyApiService;

    public OverseerrController(NtfyApiService ntfyApiServivce)
    {
        _ntfyApiService = ntfyApiServivce;
    }

    [HttpPost]
    public async Task<IActionResult> PostPayload([FromBody] OverseerrNotification payload)
    {
        if (payload == null)
        {
            return BadRequest("Invalid payload.");
        }

        var result = await _ntfyApiService.SendDataAsync(OverseerrToNtfy.Convert(payload), DotNetEnv.Env.GetString(EnvVars.OVERSEERR_TOPIC));

        if (result)
        {
            return Ok("Data forwarded successfully.");
        }

        return StatusCode(500, "Error forwarding data to ntfy.sh API.");
    }
}
