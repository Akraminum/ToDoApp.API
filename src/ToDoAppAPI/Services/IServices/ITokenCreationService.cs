using ToDoAppAPI.Dtos.Account;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Services.IServices
{
    public interface ITokenCreationService
    {
        Task<AuthenticationResponseDto> CreateToken(UserEntity user);

    }
}
