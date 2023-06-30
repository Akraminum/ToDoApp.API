namespace ToDoAppAPI.Dtos.Users.Authenticate
{
    public class AuthenticationResponseDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
