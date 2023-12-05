using Business.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonMoveController : ControllerBase
    {
        private readonly IPokemonMoveService _pmservice;

        public PokemonMoveController(IPokemonMoveService pmservice)
        {
            _pmservice = pmservice;
        }

        [HttpPost]
        public async Task<ActionResult> Add(PokemonMove pmove)
        {
            int id = _pmservice.Add(pmove);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            PokemonMove pmove = _pmservice.Get(id);
            if (pmove == null) return NotFound();
            if (pmove.Id <= 0) return NotFound();
            return Ok(pmove);
        }

        [HttpPost("{MoveID}/Type/{TypeID}")]
        public async Task<ActionResult> RelateMoveToType([FromRoute] int MoveID, [FromRoute] int TypeID)
        {
            if (MoveID <= 0) return BadRequest();
            if (TypeID <= 0) return BadRequest();
            return Ok(_pmservice.RelateMoveToType(MoveID, TypeID));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            bool result = _pmservice.Delete(id);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}

