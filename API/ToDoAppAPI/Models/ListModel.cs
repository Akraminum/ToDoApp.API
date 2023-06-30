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
    public class ListModel : BaseModel
    {
        public string Name { get; set; } = null!;

        #region Tasks
        public IEnumerable<TaskModel>? Tasks { get; set; }
        #endregion


        #region user_access
        public IEnumerable<UserModel>? Users { get; set; }
        public IEnumerable<UserListAccessModel>? UserListAccess { get; set; }
        #endregion

    }
}
