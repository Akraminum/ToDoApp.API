

using ToDoAppAPI.Dtos.Periorities;
using ToDoAppAPI.Tasks.Dtos;

namespace ToDoAppAPI.Dtos.Lists;

public class GetListOutputDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string OwnerId { get; set; } = "";

    public List<TaskDto>? Tasks { get; set; }
    
}
