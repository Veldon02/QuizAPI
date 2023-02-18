using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.DeleteQuiz
{
    public class DeleteQuizCommandValidator : AbstractValidator<DeleteQuizCommand>
    {
        public DeleteQuizCommandValidator(IConfiguration configuration)
        {
            RuleFor(x => x.QuizId.Value).Matches(configuration["RegexPatterns:QuizId"]);
        }
    }
}
