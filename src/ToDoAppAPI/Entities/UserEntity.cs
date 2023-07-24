using Microsoft.AspNetCore.Identity;


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
