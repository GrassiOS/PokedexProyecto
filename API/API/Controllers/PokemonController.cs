using Business.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pservice;

        public PokemonController(IPokemonService pmservice)
        {
            _pservice = pmservice;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Pokemon poke)
        {
            int id = _pservice.Add(poke);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            Pokemon poke = _pservice.Get(id);
            if (poke == null) return NotFound();
            if (poke.Id <= 0) return NotFound();
            return Ok(poke);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            bool result = _pservice.Delete(id);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("{PokeID}/WeaknessType/{TypeID}")]
        public async Task<ActionResult> RelatePokeToWeaknessType([FromRoute] int PokeID, [FromRoute] int TypeID)
        {
            if (PokeID <= 0) return BadRequest();
            if (TypeID <= 0) return BadRequest();
            return Ok(_pservice.RelatePokeWeToWeaknessType(PokeID, TypeID));
        }

        [HttpPost("{PokeID}/Type/{TypeID}")]
        public async Task<ActionResult> RelatePokeToType([FromRoute] int PokeID, [FromRoute] int TypeID)
        {
            if (PokeID <= 0) return BadRequest();
            if (TypeID <= 0) return BadRequest();
            return Ok(_pservice.RelatePokeToType(PokeID, TypeID));
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllPokemon()
        {
            var pokemon = _pservice.GetAllPokemon();

            if (pokemon.Count == 0)
            {
                return NotFound("No pokemon found.");
            }

            return Ok(pokemon);
        }

        [HttpPost("{PokeID}/Move/{MoveID}")]
        public IActionResult RelatePokeToMove(int PokeID, int MoveID)
        {
            if (MoveID <= 0 || PokeID <= 0)
            {
                return BadRequest("Invalid Pokemon ID or Move ID");
            }

            var result = _pservice.RelatePokeToMove(PokeID, MoveID);

            if (result)
            {
                return Ok("Pokemon related to the Move successfully.");
            }
            else
            {
                return NotFound("Pokemon or Move not found, or an error occurred.");
            }
        }
    }
}

