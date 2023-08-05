using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ToDoAppAPI.DataBase;
using ToDoAppAPI.Dtos.Users;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Utitlities.Auth;

namespace ToDoAppAPI.Controllers
{
    [Authorize(Policy = Policies.AdministrativePolicy)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            UserManager<UserEntity> userManager,
            IMapper mapper,
            AppDbContext context,
            ILogger<UsersController> logger
            )
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }


        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpPost("admins")]
        public async Task<ActionResult<GetUserOutputDto>> CreateAdminUser(CreateUserInputDto InputDto)
        {
            var user = _mapper.Map<UserEntity>(InputDto);

            var result = await _userManager.CreateAsync(user, InputDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            result = await _userManager.AddToRoleAsync(user, Roles.Admin); 
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            return CreatedAtAction(
                nameof(GetUser),
                new { username = InputDto.UserName },
                _mapper.Map<GetUserOutputDto>(user)
            );
        }

        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpGet("admins")]
        public async Task<ActionResult<List<GetUserOutputDto>>> getAllAdmins()
        {
            var admins = await _userManager.GetUsersInRoleAsync(Roles.Admin);

            return _mapper.Map<List<GetUserOutputDto>>(admins);
        }

        
        [HttpGet("{UserName}")]
        public async Task<ActionResult<GetUserOutputDto>> GetUser([FromRoute]GetUserInputDto InputDto)
        {
            UserEntity user = await _userManager.FindByNameAsync(InputDto.UserName);
            if (user == null){
                return NotFound(new { description = "no user found" });
            }
            
            if (!(await IsValidAuthority(user))){
                return Forbid();
            }

            return _mapper.Map<GetUserOutputDto>(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserOutputDto>>> GetAllUser()
        {
            // SELECT [user].[Id], [user].[Email]
            // FROM [AspNetUsers] AS [user]
            // WHERE NOT (EXISTS (
            //     SELECT DISTINCT 1
            //     FROM [AspNetUserRoles] AS [ur]
            //     WHERE [ur].[UserId] = [user].[Id]))
            // get non admin users
            var users = await _userManager.Users.Where(u => 
                !_context.UserRoles.Select(ur => ur.UserId).Distinct().Contains(u.Id)
            ).ToListAsync();
            
            return _mapper.Map<List<GetUserOutputDto>>(users);
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult> DeleteUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound(new { description = "no user found" });

            if (!(await IsValidAuthority(user)))
                return Forbid();

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return NoContent();
        }

        [HttpPost("ResetPassword/{userName}")]
        public async Task<ActionResult> ResetPassword(string userName, ResetUserPasswordInputDto inputDto)
        {
            UserEntity user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound(new { description = "no user found" });

            if (!(await IsValidAuthority(user)))
                return Forbid();

            user.PasswordHash = _userManager.PasswordHasher
                    .HashPassword(user, inputDto.NewPassword);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Accepted();
        }


        // assign admin role to user
        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpPost("giveAdminRole/{userName}")]
        public async Task<ActionResult> AssignAdminRole(string userName)
        {
            UserEntity user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound(new { description = "no user found" });

            var result = await _userManager.AddToRoleAsync(user, Roles.Admin); 
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Accepted();
        }
        
        // remove admin role from user
        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpDelete("removeAdminRole/{userName}")]
        public async Task<ActionResult> RemoveAdminRole(string userName)
        {
            UserEntity user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound(new { description = "no user found" });

            var result = await _userManager.RemoveFromRoleAsync(user, Roles.Admin); 
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Accepted();
        }




        private async Task<bool> IsValidAuthority(UserEntity targetUser)
        {
            if ((await _userManager.IsInRoleAsync(targetUser, Roles.Admin)))
            {
                var isCurrentSupperAdmin = User.Claims.Any(x =>
                                            x.Type == ClaimTypes.Role &&
                                            x.Value == Roles.SuperAdmin); 
                if (isCurrentSupperAdmin)
                    return true;
                return false;
            }

            return true;
        }

    }
}
