using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Queries.Login
{
    public class LoginQueryValidator:AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator(IConfiguration configuration)
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).Matches(configuration["RegexPatterns:Password"]);
        }
    }
}
