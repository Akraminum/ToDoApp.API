using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Services.IServices;
using ToDoAppAPI.Services;
using ToDoAppAPI.Dtos.Users.Authenticate;

namespace ToDoAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<UserEntity> _userManager;
        private ITokenCreationService _jwtService;

        public AuthController(
            UserManager<UserEntity> userManager,
            ITokenCreationService jwtService
            )
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        // POST: api/Users/BearerToken
        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponseDto>> CreateBearerToken(AuthenticationRequestDto request)
        {

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return BadRequest("Bad UserName");


            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
                return BadRequest("Bad Password");


            var token = await _jwtService.CreateToken(user);

            return Ok(token);
        }
    }
}
