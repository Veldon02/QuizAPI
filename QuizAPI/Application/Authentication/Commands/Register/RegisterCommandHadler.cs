using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.UserAggregate;
using MediatR;
using OneOf;

namespace Application.Authentication.Commands.Register
{
    public class RegisterCommandHadler : IRequestHandler<RegisterCommand, OneOf<AuthenticationResult, IError>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IHasher _hasher;

        public RegisterCommandHadler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IHasher hasher)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _hasher = hasher;
        }
        public async Task<OneOf<AuthenticationResult, IError>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user != null) return new DuplicateEmailError();

            var passwordHash = _hasher.Hash(request.Password);
            user = User.Create(request.FisrtName, request.LastName, request.Email, request.Username, passwordHash);
            
            user = await _userRepository.AddAsync(user);
            var token =  _jwtTokenGenerator.GenerateToken(user);
            var result = new AuthenticationResult(
                Email: user.Email,
                Username: user.Username,
                Token: token);

            return result;
        }
    }
}
