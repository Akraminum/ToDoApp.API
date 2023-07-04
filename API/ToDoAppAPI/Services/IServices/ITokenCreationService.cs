using Microsoft.AspNetCore.Identity;
using ToDoAppAPI.Dtos.Users.Authenticate;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Services.IServices
{
    public interface ITokenCreationService
    {
        Task<AuthenticationResponseDto> CreateToken(UserEntity user);

    }
}
