using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Queries.GetQuiz
{
    public class GetQuizQueryValidator:AbstractValidator<GetQuizQuery>
    {
        public GetQuizQueryValidator(IConfiguration configuration)
        {
            RuleFor(x => x.QuizId.Value).Matches(configuration["RegexPatterns:QuizId"]);
        }
    }
}
