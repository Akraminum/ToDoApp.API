using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppAPI.Entities
{
    public class StepEntity : BaseEntity<int>
    {
        [StringLength(100)]
        public string Body { get; set; } = null!;
        public bool IsComplete { get; set; } = false;


        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public TaskEntity? Task { get; set; }

        public int UserCreatedId { get; set; }
        [ForeignKey("UserCreatedId")]
        public TaskEntity? UserCreated { get; set; }
    }
}
