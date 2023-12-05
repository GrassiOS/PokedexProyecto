using Business.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly IBattleService _bservice;

        public BattleController(IBattleService bservice)
        {
            _bservice = bservice;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Battle bmove)
        {
            int id = _bservice.Add(bmove);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            Battle bmove = _bservice.Get(id);
            if (bmove == null) return NotFound();
            if (bmove.Id <= 0) return NotFound();
            return Ok(bmove);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            bool result = _bservice.Delete(id);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}

