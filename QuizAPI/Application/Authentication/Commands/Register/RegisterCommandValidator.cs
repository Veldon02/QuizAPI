using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(IConfiguration _configuration)
        {
            RuleFor(x => x.FisrtName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Username).Matches(_configuration["RegexPatterns:Username"]);
            RuleFor(x => x.Password).Matches(_configuration["RegexPatterns:Password"]);
        }
    }
}
