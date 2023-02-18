using Application.Authentication;
using Application.Authentication.Commands.Register;
using Application.Authentication.Queries.Login;
using Mapster;
using Presentation.Api.Contracts.Authentication;

namespace QuizAPI.Mapping
{
    public class AuthenticationMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>()
                .Map(dest => dest, src => src);

            config.NewConfig<RegisterRequest, RegisterCommand>()
                .Map(dest => dest, src => src);

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src);
        }
    }
}
