using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using ToDoAppAPI.Exceptions;
using ToDoAppAPI.Utitlities.Auth;

namespace ToDoAppAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("Anonymous")]
        public string Anonymous() => "Anonymous";



        [Authorize]
        [HttpGet("Users")]
        public List<string> Users()
        {
            return GetClaims();
        }


        //[Authorize(Roles = "Admin, SuperAdmin")]
        [Authorize(Policy = Policies.AdministrativePolicy)]
        [HttpGet("Admin")]
        public List<string> Admins()
        {
            return GetClaims();
        }

        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpGet("SuperAdmin")]
        public List<string> SuperAdmin()
        {
            return GetClaims();
        }


        [HttpGet("validation")]
        public IActionResult validation([FromQuery] [Required] int id, [FromQuery] [Required] string name)
        {
            return Ok(id);
        }

        [HttpGet("Exception")]
        public IActionResult Exception()
        {
            // throw new EntityExistsException();
            throw new EntityExistsException("The requested weather forecast exists");
        }

        private List<string> GetClaims()
        {
            return User.Claims.Select(claim => $"claimName={claim.Type}, claimValue={claim.Value})").ToList();
        }


    }
}
