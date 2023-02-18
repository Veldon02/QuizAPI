using System.ComponentModel.DataAnnotations;

namespace Presentation.Api.Contracts.Authentication
{
    public record LoginRequest(
        string Email,
        string Password);
}
