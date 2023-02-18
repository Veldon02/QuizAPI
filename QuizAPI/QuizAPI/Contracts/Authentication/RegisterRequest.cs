using System.ComponentModel.DataAnnotations;

namespace Presentation.Api.Contracts.Authentication
{
    public record RegisterRequest(
        string FisrtName,
        string LastName,
        string Username,
        string Email,
        string Password
    );


}
