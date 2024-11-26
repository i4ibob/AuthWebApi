namespace AuthWebApi.Models
{
    public record UserLoginRequest(string UserLoginOrEmail, string Password);
}
