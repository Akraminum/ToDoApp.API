using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Users
{
    public class ResetUserPasswordInputDto
    {

        [MinLength(6)]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
