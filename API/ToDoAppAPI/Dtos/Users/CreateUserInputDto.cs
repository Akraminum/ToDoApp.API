using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Users
{
    public class CreateUserInputDto
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
    }
}
