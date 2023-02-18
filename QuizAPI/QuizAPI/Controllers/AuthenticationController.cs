using Application.Authentication.Commands.Register;
using Application.Authentication.Queries.Login;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Api.Contracts.Authentication;
using Presentation.Api.Controllers;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var registerCommand = _mapper.Map<RegisterCommand>(registerRequest);
            var registrationResult = await _mediator.Send(registerCommand);

            return registrationResult.Match(
                authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
                error => Problem(statusCode:(int)error.StatusCode, title: error.Title) 
            );

        }

        [HttpPost("login-user")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var loginQuery = _mapper.Map<LoginQuery>(loginRequest);
            var loginResult = await _mediator.Send(loginQuery);

            return loginResult.Match(
                authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
                error => Problem(statusCode:(int)error.StatusCode, title: error.Title));
        }
    }
}
