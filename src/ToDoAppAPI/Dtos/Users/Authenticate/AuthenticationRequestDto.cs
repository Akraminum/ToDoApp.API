using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Users.Authenticate
{
    public class AuthenticationRequestDto
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
