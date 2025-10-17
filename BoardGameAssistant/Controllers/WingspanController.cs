using BoardGameAssistant.ServiceContracts.Wingspan;
using BoardGameAssistant.ServiceContracts.Wingspan.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameAssistant.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WingspanController : ControllerBase
{
    private readonly IWingspanGameService WingspanGameService;

    public WingspanController(IWingspanGameService WingspanGameService)
    {
        this.WingspanGameService = WingspanGameService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(WingspanGame), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateGame([FromBody] NewWingspanGame gameSettings)
    {
        var game = await WingspanGameService.CreateGameAsync(gameSettings);
        return Ok(game);
    }

    [HttpGet("{gameId:int}")]
    [ProducesResponseType(typeof(WingspanGame), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGame([FromRoute] int gameId)
    {
        var game = await WingspanGameService.GetGameAsync(gameId);
        return Ok(game);
    }


}
