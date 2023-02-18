namespace Presentation.Api.Contracts.Quizzes
{
    public record GetQuizQuestionRequest(string QuizId, Guid QuestionId);
}
