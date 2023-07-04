using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Users
{
    public class GetUserInputDto
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; } = null!;
    }
}
