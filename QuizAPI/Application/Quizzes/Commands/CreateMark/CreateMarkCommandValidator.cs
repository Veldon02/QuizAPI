using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.CreateMark
{
    public class CreateMarkCommandValidator : AbstractValidator<CreateMarkCommand>
    {
        public CreateMarkCommandValidator(IConfiguration configuration)
        {
            RuleFor(x => x.QuizId.Value).Matches(configuration["RegexPatterns:QuizId"]);
            RuleFor(x => x.PasserId).NotEmpty();
            RuleFor(x => x.Mark).GreaterThanOrEqualTo(0);
        }
    }
}
