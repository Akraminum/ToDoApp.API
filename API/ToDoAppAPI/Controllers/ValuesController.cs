using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("Anonymous")]
        public string Anonymous() => "Anonymous";

        [Authorize]
        [HttpGet("User")]
        public string Users() => "User";

        [Authorize(Roles = "admin")]
        [HttpGet("Admin")]
        public string Admins() => "Admin";
    }
}
