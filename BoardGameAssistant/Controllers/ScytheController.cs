using BoardGameAssistant.ServiceContracts.Scythe;
using BoardGameAssistant.ServiceContracts.Scythe.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
    [ProducesResponseType(typeof(ScytheGame), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateGame([FromBody] NewScytheGame gameSettings)
    {
        var game = await scytheGameService.CreateGameAsync(gameSettings);
        return Ok(game);
    }

    [HttpGet("{gameId:int}")]
    [ProducesResponseType(typeof(ScytheGame), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGame([FromRoute] int gameId)
    {
        var game = await scytheGameService.GetGameAsync(gameId);
        return Ok(game);
    }


}
