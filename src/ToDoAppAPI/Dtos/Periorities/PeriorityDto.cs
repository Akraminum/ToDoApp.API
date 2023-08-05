namespace ToDoAppAPI.Dtos.Periorities;

public class PeriorityDto
{
    public string Name { get; set; } = null!;
    public int Order { get; set; }
    public string Color { get; set; } = "#ffffff";
}
