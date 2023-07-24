using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoAppAPI.Entities
{
    public class ListEntity : BaseEntity<int>
    {
        public string Name { get; set; } = null!;

        public string OwnerId { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public UserEntity? Owner { get; set; }


        public IList<UserEntity>? AssociatedUsers { get; set; }

        public IList<UsersLists>? UsersLists { get; set; }

        public IList<TaskEntity>? Tasks { get; set; }

    }
}
