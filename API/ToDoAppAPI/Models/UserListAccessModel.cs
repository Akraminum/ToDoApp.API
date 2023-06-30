using ToDoAppAPI.Model;

namespace ToDoAppAPI.Models
{
    public class UserListAccessModel: BaseModel
    {
        public int UserId { get; set; }
        public UserModel? User { get; set; }
        public int ListId { get; set; }
        public ListModel? List { get; set; }

        public int AccessLevel { get; set; }
    }
}
