using AutoMapper;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Dtos.Lists;

public class UpdateListOutputDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
