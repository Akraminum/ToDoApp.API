using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Users
{
    public class CreateUserInputDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
