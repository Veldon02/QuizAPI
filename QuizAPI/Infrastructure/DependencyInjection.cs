using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Infrastructure.Authentication;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddAuthentication(configuration);
            return services;
        }

        private static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IMarkRepository, MarkRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPasserRepository, PasserRepository>();

            services.AddDbContext<QuizDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:Default"]);
            });
        }

        private static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IHasher, Hasher>();

            TokenValidationParameters tokenValidationParameter = CreateTokenValidationParametors(configuration);

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = tokenValidationParameter;
            });
        }

        private static TokenValidationParameters CreateTokenValidationParametors(IConfiguration configuration)
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Secret"])),

                ValidateIssuer = true,
                ValidIssuer = configuration["JWT:Issuer"],

                ValidateAudience = true,
                ValidAudience = configuration["JWT:Audience"],

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }
    }
}
