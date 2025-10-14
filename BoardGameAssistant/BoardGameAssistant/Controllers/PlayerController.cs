using BoardGameAssistant.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameAssistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public PlayerController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync(
            [FromServices] IPlayerNameProvider playerNameProvider,
            [FromQuery] string? contains = null,
            [FromQuery] int? skip = null,
            [FromQuery] int? take = null,
            CancellationToken cancellationToken = default)
        {
            var players = await playerNameProvider.GetPlayersAsync(contains, skip, take, cancellationToken);
            return Ok(players);
        }
    }
}
