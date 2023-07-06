using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ToDoAppAPI.Dtos.Users;
using ToDoAppAPI.Entities;
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

        public UsersController(
            UserManager<UserEntity> userManager
            )
        {
            _userManager = userManager;
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

            if (!(await IsValidAuthority(user)))
                return Forbid();


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

            if (!(await IsValidAuthority(user)))
                return Forbid();


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

            if (!(await IsValidAuthority(user)))
                return Forbid();

            user.PasswordHash = _userManager.PasswordHasher
                    .HashPassword(user, inputDto.NewPassword);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Accepted();
        }


                         /////////////////////////////////////////////
                        /////////////////// ADMINS //////////////////
                       /////////////////////////////////////////////
        // CreateAdminUser
        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpPost("admins")]
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

        [HttpGet("admins")]
        public async Task<ActionResult<List<GetUserOutputDto>>> getAllAdmins()
        {

            var admins = await _userManager.GetUsersInRoleAsync(Roles.Admin);

            return admins.Select(x => new GetUserOutputDto
            {
                UserName = x.UserName,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();
        }


        // assign admin role
        // remove admin role

        private async Task<bool> IsValidAuthority(UserEntity targetUser)
        {
            bool isTargetingAdmin = (await _userManager.GetRolesAsync(targetUser)).Any();
            if (isTargetingAdmin)
            {
                var isCurrentSupperAdmin = User.Claims.Any(x =>
                                            x.ValueType.Equals(ClaimTypes.Role) &&
                                            x.ValueType == Roles.SuperAdmin);
                if (!isCurrentSupperAdmin)
                    return false;
            }

            return true;
        }

    }
}
