using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Dtos
{
    public class ListDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<TaskEntity>? Tasks { get; set; }

        public IEnumerable<UserEntity>? Users { get; set; }

    }
}
