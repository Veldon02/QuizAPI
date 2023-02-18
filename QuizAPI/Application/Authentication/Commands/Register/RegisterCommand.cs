using Domain.Common.Errors;
using MediatR;
using OneOf;


namespace Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FisrtName,
        string LastName,
        string Username,
        string Email,
        string Password
    ) : IRequest<OneOf<AuthenticationResult, IError>>;
}
