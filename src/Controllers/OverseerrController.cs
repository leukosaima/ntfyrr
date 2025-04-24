using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ntfyrr.Models;
using ntfyrr.Services;
using System.Text;

namespace ntfyrr.Controllers;

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
    public async Task<IActionResult> PostPayload([FromBody] OverseerrModel payload)
    {
        if (payload == null)
        {
            return BadRequest("Invalid payload.");
        }

        var result = await _ntfyApiService.SendDataAsync(OverseerrToNtfy.Convert(payload));

        if (result)
        {
            return Ok("Data forwarded successfully.");
        }

        return StatusCode(500, "Error forwarding data to ntfy.sh API.");
    }
}
