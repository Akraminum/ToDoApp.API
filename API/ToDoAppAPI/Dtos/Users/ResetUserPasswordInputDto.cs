using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Users
{
    public class ResetUserPasswordInputDto
    {
        [MinLength(6)]
        [MaxLength(60)]
        [DataType(DataType.Password)]
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [MinLength(6)]
        [MaxLength(60)]
        [DataType(DataType.Password)]
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
