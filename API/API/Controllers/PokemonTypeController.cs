using Business.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonTypeController : ControllerBase
    {
        private readonly IPokemonTypeService _ptservice;

        public PokemonTypeController(IPokemonTypeService ptservice)
        {
            _ptservice = ptservice;
        }

        [HttpPost]
        public async Task<ActionResult> Add(PokemonType ptype)
        {
            int id = _ptservice.Add(ptype);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            PokemonType ptype = _ptservice.Get(id);
            if (ptype == null) return NotFound();
            if (ptype.Id <= 0) return NotFound();
            return Ok(ptype);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            bool result = _ptservice.Delete(id);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllTypes()
        {
            var types = _ptservice.GetAllTypes();

            if (types.Count == 0)
            {
                return NotFound("No pokemon found.");
            }

            return Ok(types);
        }
    }
}

