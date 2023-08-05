using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Account;

public class UpdateInputDto
{
    [MinLength(3)] [MaxLength(50)]
    public string? FirstName { get; set; }

    [MinLength(3)] [MaxLength(50)]
    public string? LastName { get; set; }
}
