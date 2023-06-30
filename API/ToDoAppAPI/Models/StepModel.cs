using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppAPI.Model
{
    public class StepModel : BaseModel
    {
        [StringLength(100)]
        public string Name { get; set; }
        public bool IsComplete { get; set; } = false;
        
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public TaskModel? Task { get; set; }
    }
}
