using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Services.IServices;
using ToDoAppAPI.Services;
using ToDoAppAPI.Dtos.Users.Authenticate;
using Microsoft.Win32;
using Microsoft.AspNetCore.Components.Forms;
using ToDoAppAPI.Dtos.Users;
using ToDoAppAPI.Exceptions;
using System.ComponentModel.DataAnnotations;

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
        public async Task<ActionResult<AuthenticationResponseDto>> Authonticate(AuthenticationRequestDto request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                throw new BadRequestExeption("Invalid UserName");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
                throw new BadRequestExeption("Invalid Password");


            var token = await _jwtService.CreateToken(user);

            return Ok(token);
        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterInputDto inputDto)
        {
            var result = await _userManager.CreateAsync(
                new UserEntity()
                {
                    UserName = inputDto.Email,
                    Email = inputDto.Email,
                    FirstName = inputDto.FirstName,
                    LastName = inputDto.LastName,
                },
                inputDto.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Accepted(new { UserName = inputDto.Email });
        }

        // send confirmation mail after registering

        // Resend confirmation mail endpoint
        // send reset password token mail endpoint
        // reset password with token endpoint
        // updating self data endpoint

    }
}
