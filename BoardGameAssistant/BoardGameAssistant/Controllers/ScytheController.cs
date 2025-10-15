using BoardGameAssistant.Client.Services;
using BoardGameAssistant.ServiceContracts.Scythe.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BoardGameAssistant.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScytheController : ControllerBase
{
    private readonly IScytheGameService scytheGameService;

    public ScytheController(IScytheGameService scytheGameService)
    {
        this.scytheGameService = scytheGameService;
    }


    [HttpPost]
    [ProducesResponseType(typeof(ScytheGame), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateGame([FromBody] string? gameName)
    {
        var game = await scytheGameService.CreateGameAsync(gameName);
        return Ok(game);
    }
}
