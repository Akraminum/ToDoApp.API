using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppAPI.Entities
{
    public class TaskEntity : BaseEntity<int>
    {
        [StringLength(100)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsComplete { get; set; } = false;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateDue { get; set; } = null;
        public DateTime? DateCompleted { get; set; } = null;


        #region Periority rel
        public int? PriorityId { get; set; }
        [ForeignKey(nameof(PriorityId))]
        public PriorityEntity? Priority { get; set; }
        #endregion


        #region List rel
        public int ListId { get; set; }
        [ForeignKey(nameof(ListId))]
        public ListEntity? List { get; set; }
        #endregion


        #region user_created_rel
        public string OwnerId { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public UserEntity? Owner { get; set; }
        #endregion

        #region user_completed_rel
        public string? UserCompletedId { get; set; } = null!;
        [ForeignKey(nameof(UserCompletedId))]
        public UserEntity? UserCompleted { get; set; }
        #endregion

        #region Steps rel
        public IEnumerable<StepEntity>? Steps { get; set; }
        #endregion

    }
}
