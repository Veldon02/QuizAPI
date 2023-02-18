namespace Presentation.Api.Contracts.Authentication
{
    public record AuthenticationResponse(
        string Email,
        string Username,
        string Token);
}
