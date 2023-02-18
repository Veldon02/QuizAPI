using Domain.PasserAggregate.ValueObjects;
using Domain.QuizAggregate.ValueObjects;

namespace Presentation.Api.Contracts.Quizzes
{
    public record GetPasserMarkRequest(string quizId, string passerId);
}
