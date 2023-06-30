using Microsoft.AspNetCore.Identity;
using ToDoAppAPI.Dtos.Users.Authenticate;

namespace ToDoAppAPI.Services.IServices
{
    public interface ITokenCreationService
    {
        public AuthenticationResponseDto CreateToken(IdentityUser user);
    }
}
