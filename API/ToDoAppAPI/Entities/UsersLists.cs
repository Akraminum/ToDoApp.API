namespace ToDoAppAPI.Entities
{
    public class UsersLists
    {
        public string UserId { get; set; } = null!;
        public UserEntity? User { get; set; }

        public int ListId { get; set; }
        public ListEntity? List { get; set; }


        public byte AccessLevel { get; set; }
    }
}
