using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos.Users
{
    public class GetUserOutputDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
