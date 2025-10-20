using BoardGameAssistant.ServiceContracts.Common;
using BoardGameAssistant.ServiceContracts.Common.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoardGameAssistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameProvider gameProvider;

        public GamesController(IGameProvider gameProvider)
        {
            this.gameProvider = gameProvider;
        }

        // GET: api/<GamesController>
        [HttpGet]
        public async Task<IEnumerable<BoardGame>> Get([FromQuery] string? name = null, [FromQuery] int? skip = null, [FromQuery] int? take = null, CancellationToken cancellationToken = default)
        {
            return await gameProvider.GetBoardGames(
                name,
                Math.Max(skip ?? 0, 0),
                Math.Clamp(take ?? 10, 0, 100),
                false,
                cancellationToken);
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
