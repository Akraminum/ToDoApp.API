using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Account
{
    public class AuthenticationRequestDto
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; } = null!;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
