using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Services.IServices;
using ToDoAppAPI.Dtos.Account;
using ToDoAppAPI.Exceptions;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace ToDoAppAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<UserEntity> _userManager;
        private ITokenCreationService _jwtService;
        private IMapper _mapper;

        public AccountController(
            UserManager<UserEntity> userManager,
            ITokenCreationService jwtService,
            IMapper mapper
            ) 
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        // GET: api/Users
        [AllowAnonymous]
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


        // POST: api/Users/BearerToken
        [AllowAnonymous]
        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponseDto>> AuthonticateWithBearerToken(AuthenticationRequestDto request)
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


        // reset password
        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordInputDto inputDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            if (user == null)
                return BadRequest("Invalid UserName");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, inputDto.CurrenrtPassword);
            if (!isPasswordValid)
                return BadRequest("Invalid Password");

            var result = await _userManager.ChangePasswordAsync(user, inputDto.CurrenrtPassword, inputDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Accepted();
        }

        // update user data
        [HttpPut("Update")]
        public async Task<ActionResult> Update(UpdateInputDto inputDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            if (user == null)
                return BadRequest("Invalid UserName");

            _mapper.Map(inputDto, user);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Accepted();
        }



        // send confirmation mail after registering
        // Resend confirmation mail endpoint
        // send reset password token mail endpoint

    }
}
