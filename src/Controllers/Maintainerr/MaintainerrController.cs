using Microsoft.AspNetCore.Mvc;
using ntfyrr.Models.Maintainerr;
using ntfyrr.Services;

namespace ntfyrr.Controllers.Maintainerr;

[ApiController]
[Route("[controller]")]
public class MaintainerrController : ControllerBase
{
    private readonly NtfyApiService _ntfyApiService;

    public MaintainerrController(NtfyApiService ntfyApiServivce)
    {
        _ntfyApiService = ntfyApiServivce;
    }

    [HttpPost]
    public async Task<IActionResult> PostPayload([FromBody] MaintainerrNotification payload)
    {
        if (payload == null)
        {
            return BadRequest("Invalid payload.");
        }

        var result = await _ntfyApiService.SendDataAsync(MaintainerrToNtfy.Convert(payload));

        if (result)
        {
            return Ok("Data forwarded successfully.");
        }

        return StatusCode(500, "Error forwarding data to ntfy.sh API.");
    }
}
