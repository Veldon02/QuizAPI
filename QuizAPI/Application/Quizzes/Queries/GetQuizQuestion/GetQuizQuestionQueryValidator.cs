using FluentValidation;
using Microsoft.Extensions.Configuration;

namespace Application.Quizzes.Queries.GetQuizQuestion
{
    public class GetQuizQuestionQueryValidator : AbstractValidator<GetQuizQuestionQuery>
    {
        public GetQuizQuestionQueryValidator(IConfiguration configuration)
        {
            RuleFor(x => x.QuizId.Value)
                .Matches(configuration["RegexPatterns:QuizId"]);
            RuleFor(x => x.QuestionId).NotEmpty();
        }
    }
}
