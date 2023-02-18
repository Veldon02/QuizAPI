using Application.Common.Behaivor;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Authentication.Queries.Login;
using Application.Authentication.Commands.Register;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddValidation();
            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IValidator<LoginQuery>, LoginQueryValidator>();
            services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }

        
    }
}
