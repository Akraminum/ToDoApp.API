using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppAPI.Model
{
    public class PriorityModel : BaseModel
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Color { get; set; } = "#ffffff";

        // list of taskmodel
        public IEnumerable<TaskModel>? Tasks { get; set; }
    }
}
