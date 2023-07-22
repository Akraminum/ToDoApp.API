using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsComplete { get; set; } = false;
        public DateTime? DueDate { get; set; }

        // DOTO:
        public int? ListId { get; set; }

        public PriorityEntity? Priority { get; set; }


    }
}
