using System;
using Business.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;

        public UserController(IUserService usrservice)
        {
            _userservice = usrservice;
        }

        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            int id = _userservice.Add(user);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            User user = _userservice.Get(id);
            if (user == null) return NotFound();
            if (user.Id <= 0) return NotFound();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            bool result = _userservice.Delete(id);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("Email/{email}/Password/{password}")]
        public async Task<ActionResult> GetUserFromEmailandPassword([FromRoute] String email, String password)
        {
            if (email == null) return null;
            if (password == null) return null;
            User user = _userservice.GetUserFromEmailandPassword(email, password);
            if (user == null) return NotFound();
            if (user.Id <= 0) return NotFound();
            return Ok(user);
        }

        [HttpPost("{UserID}/Poke/{PokeID}")]
        public IActionResult RelateUserToPoke(int UserID, int PokeID)
        {
            if (UserID <= 0 || PokeID <= 0)
            {
                return BadRequest("Invalid Pokemon ID or Move ID");
            }

            var result = _userservice.RelateUserToPoke( UserID,  PokeID);

            if (result)
            {
                return Ok("User related to the Poke successfully.");
            }
            else
            {
                return NotFound("Pokemon or User not found, or an error occurred.");
            }
        }

        [HttpDelete("{UserID}/Poke/{PokeID}")]
        public IActionResult UnrelateUserToPoke(int UserID, int PokeID)
        {
            if (UserID <= 0 || PokeID <= 0)
            {
                return BadRequest("Invalid Pokemon ID or Move ID");
            }

            var result = _userservice.UnrelateUserFromPoke( UserID,  PokeID);

            if (result)
            {
                return Ok("User related to the Poke successfully.");
            }
            else
            {
                return NotFound("Pokemon or User not found, or an error occurred.");
            }
        }
    }
}

