using Business.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleMoveController : ControllerBase
    {
        private readonly IBattleMoveService _bmoveservice;

        public BattleMoveController(IBattleMoveService bmservice)
        {
            _bmoveservice = bmservice;
        }

        [HttpPost]
        public async Task<ActionResult> Add(BattleMove bmove)
        {
            int id = _bmoveservice.Add(bmove);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            BattleMove bmove = _bmoveservice.Get(id);
            if (bmove == null) return NotFound();
            if (bmove.Id <= 0) return NotFound();
            return Ok(bmove);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            bool result = _bmoveservice.Delete(id);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}

