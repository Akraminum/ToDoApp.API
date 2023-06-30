using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.Model
{
    public class UserModel: BaseModel
    {
        // Unique
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        // relations


        #region ListsCanAccess
        public IEnumerable<ListModel>? Lists { get; set; }
        public IEnumerable<UserListAccessModel>? UserListAccess { get; set; }
        #endregion

        #region Tasks
        public IEnumerable<TaskModel>? Tasks { get; set; }
        #endregion

    }
}
