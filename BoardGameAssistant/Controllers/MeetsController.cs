using BoardGameAssistant.Entities.Planner;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoardGameAssistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetsController : ControllerBase
    {
        // GET: api/<MeetsController>
        [HttpGet]
        public async Task<List<GameMeet>> GetAsync([FromQuery] DateTime? from = null, [FromQuery] DateTime? to = null, CancellationToken cancellationToken = default)
        {
            if(!from.HasValue)
                from = DateTime.Now;

            if(!to.HasValue)
                to = from.Value.AddDays(7);



            return [];
        }

        // GET api/<MeetsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MeetsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MeetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
