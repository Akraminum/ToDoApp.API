namespace ToDoAppAPI.Dtos.Account;

public class ResetPasswordInputDto
{
    public string CurrenrtPassword { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}
