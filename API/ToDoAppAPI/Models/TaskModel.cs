using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppAPI.Model
{
    public class TaskModel : BaseModel
    {
        [StringLength(100)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsComplete { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        // DOTO:
        #region List rel
        public int ListId { get; set; }

        [ForeignKey(nameof(ListId))]
        public ListModel? List { get; set; }
        #endregion

        #region Steps rel
        public IEnumerable<StepModel>? Steps { get; set; }
        #endregion

        #region Periority rel
        public int PriorityId { get; set; }

        [ForeignKey(nameof(PriorityId))]
        public PriorityModel? Priority { get; set; }
        #endregion

        #region user_created_rel
        public int UserCreatedId { get; set; }
        [ForeignKey(nameof(UserCreatedId))]
        public UserModel? UserCreated { get; set; }
        #endregion


    }
}
