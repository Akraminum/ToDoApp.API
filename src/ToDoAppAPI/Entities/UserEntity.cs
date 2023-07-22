using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoAppAPI.Entities
{
    public class UserEntity: IdentityUser
    {
        // Unique
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public IList<ListEntity>? AssociatedLists { get; set; }
        public IList<UsersLists>? UsersLists { get; set; }

    }
}
