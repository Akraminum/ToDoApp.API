using ToDoAppAPI.Model;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.Dtos
{
    public class ListDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<TaskModel>? Tasks { get; set; }

        public IEnumerable<UserModel>? Users { get; set; }

    }
}
