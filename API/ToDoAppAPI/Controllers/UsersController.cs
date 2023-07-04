using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Dtos.Users;
using ToDoAppAPI.Dtos.Users.Authenticate;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Services;
using ToDoAppAPI.Services.IServices;

namespace ToDoAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UsersController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly ITokenCreationService _jwtService;

        public UsersController(
            UserManager<UserEntity> userManager,
            ITokenCreationService jwtService
            )
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }


        [HttpPost]
        public async Task<ActionResult<CreateUserOutputDto>> CreateUser(CreateUserInputDto InputDto)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var result = await _userManager.CreateAsync(
                new UserEntity() { UserName = InputDto.UserName, Email = InputDto.Email },
                InputDto.Password
            );

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return CreatedAtAction(
                nameof(GetUser),
                new { username = InputDto.UserName },
                new CreateUserOutputDto() { Email = InputDto.Email, UserName = InputDto.UserName });
        }

        [HttpGet]
        public async Task<ActionResult<GetUserOutputDto>> GetUser([FromQuery]GetUserInputDto InputDto)
        {
            IdentityUser user = await _userManager.FindByNameAsync(InputDto.UserName);
            if (user == null)
                return NotFound(new { erroe = "no user found" });

            return new GetUserOutputDto
            {
                UserName = user.UserName,
                Email = user.Email
            };
        }


        // POST: api/Users/BearerToken
        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponseDto>> CreateBearerToken(AuthenticationRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            } 

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return BadRequest("Bad credentials");


            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
                return BadRequest("Bad credentials");


            var token = await _jwtService.CreateToken(user);

            return Ok(token);
        }

    }
}
