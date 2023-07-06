using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAppAPI.Dtos.Users;
using ToDoAppAPI.Dtos.Users.Authenticate;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Services;
using ToDoAppAPI.Services.IServices;
using ToDoAppAPI.Utitlities.Auth;

namespace ToDoAppAPI.Controllers
{
    [Authorize(Policy = Policies.AdministrativePolicy)]
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


        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<CreateUserOutputDto>> CreateUser(CreateUserInputDto InputDto)
        {
            var result = await _userManager.CreateAsync(
                new UserEntity()
                {
                    UserName = InputDto.UserName,
                    Email = InputDto.Email,
                    FirstName = InputDto.FirstName,
                    LastName = InputDto.LastName,
                },
                InputDto.Password
            );

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return CreatedAtAction(
                nameof(GetUser),
                new { username = InputDto.UserName },
                new CreateUserOutputDto() { Email = InputDto.Email, UserName = InputDto.UserName });
        }

        // GET: api/Users?UserName
        [HttpGet("{UserName}")]
        public async Task<ActionResult<GetUserOutputDto>> GetUser([FromRoute]GetUserInputDto InputDto)
        {
            UserEntity user = await _userManager.FindByNameAsync(InputDto.UserName);
            if (user == null)
                return NotFound(new { erroe = "no user found" });

            return new GetUserOutputDto
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName, 
                LastName = user.LastName,
            };

        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<GetUserOutputDto>>> GetAllUser()
        {
            var users = await _userManager.Users.ToListAsync();

            return users.Select( x => new GetUserOutputDto
            {
                UserName = x.UserName,
                Email = x.Email,
                FirstName= x.FirstName,
                LastName = x.LastName,
            }).ToList();
        }

        [HttpPut("{userName}")]
        public async Task<ActionResult<UpdateUserOutputDto>> UpdateUser(string userName, UpdateUserInputDto inputDto)
        {
            UserEntity user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound(new { erroe = "no user found" });

            user.FirstName = inputDto.FirstName;
            user.LastName = inputDto.LastName;
            user.Email = inputDto.Email;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Accepted(new UpdateUserOutputDto
            {
                UserName = user.FirstName,
            });
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult> DeleteUser(string userName)
        {
            UserEntity user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound(new { erroe = "no user found" });
            //(await _userManager.GetRolesAsync(user))
            //    .Any(r => 
            //            r.Equals(Roles.Admin) || r.Equals(Roles.SuperAdmin));

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return NoContent();
        }

        [HttpPost("{userName}")]
        public async Task<ActionResult> ResetUserPassword(string userName, ResetUserPasswordInputDto inputDto)
        {
            UserEntity user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound(new { erroe = "no user found" });

            var result = await _userManager.ChangePasswordAsync(user, inputDto.CurrentPassword, inputDto.NewPassword);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Accepted();

        }


        // CreateAdminUser
        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpPost("admin")]
        public async Task<ActionResult<GetUserOutputDto>> CreateAdminUser(CreateUserInputDto InputDto)
        {
            var user = new UserEntity()
            {
                UserName = InputDto.UserName,
                Email = InputDto.Email,
                FirstName = InputDto.FirstName,
                LastName = InputDto.LastName,
            };
            var result = await _userManager.CreateAsync(
                user,
                InputDto.Password
            );
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            result = await _userManager.AddToRoleAsync(user, Roles.Admin);
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            return CreatedAtAction(
                nameof(GetUser),
                new { username = InputDto.UserName },
                new CreateUserOutputDto() { Email = InputDto.Email, UserName = InputDto.UserName });

        }


        // UpdateAdminUser
        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpPut("admin/{userName}")]
        public async Task<ActionResult<UpdateUserOutputDto>> UpdateAdminUser(string userName, UpdateUserInputDto inputDto)
        {
            UserEntity user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound(new { erroe = "no user found" });

            user.FirstName = inputDto.FirstName;
            user.LastName = inputDto.LastName;
            user.Email = inputDto.Email;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Accepted(new UpdateUserOutputDto
            {
                UserName = user.FirstName,
            });
        }

        // DeleteAdminUser
        // ResetAdminUserPassword




    }
}
