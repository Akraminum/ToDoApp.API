using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Lists;

public class CreateListInputDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

}

