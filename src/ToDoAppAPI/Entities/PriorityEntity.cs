using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppAPI.Entities
{
    public class PriorityEntity : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public int Order { get; set; }
        public string Color { get; set; } = "#ffffff";

    }
}
