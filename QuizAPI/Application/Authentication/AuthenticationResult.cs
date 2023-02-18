namespace Application.Authentication
{
    public record AuthenticationResult(
        string Email,
        string Username,
        string Token);
}
