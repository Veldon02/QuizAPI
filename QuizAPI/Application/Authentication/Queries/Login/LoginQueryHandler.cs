using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using MediatR;
using OneOf;

namespace Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, OneOf<AuthenticationResult, IError>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IHasher _hasher;
        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IHasher hasher)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _hasher = hasher;
        }
        public async Task<OneOf<AuthenticationResult, IError>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) return new NotExistingEmailError();

            if(!_hasher.Verify(request.Password,user.Password)) return new IncorrectPasswordError();

            var token = _jwtTokenGenerator.GenerateToken(user);

            var result = new AuthenticationResult(
                Email: user.Email, 
                Username: user.Username,
                Token: token);

            return result;
        }
    }
}
