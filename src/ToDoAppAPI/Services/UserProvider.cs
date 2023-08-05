using System.Security.Claims;
using ToDoAppAPI.Services.IServices;

namespace ToDoAppAPI.Services;

public class UserProvider : IUserProvider
{
    
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserId()
    {
        if (_httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
        {
            return _httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)!.Value.ToString();
        }
        else
        {
            throw new UnauthorizedAccessException("Not Logged In"); // (401)
        }

    }

    public string GetUserRole()
    {
        if (_httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
        {
            return _httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.Role)!.Value.ToString();
        }
        else
        {
            throw new UnauthorizedAccessException("Not Logged In"); // (401)
        }

    
    }
}
