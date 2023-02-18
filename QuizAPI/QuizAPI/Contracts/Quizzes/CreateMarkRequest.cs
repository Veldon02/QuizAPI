namespace Presentation.Api.Contracts.Quizzes
{
    public record CreateMarkRequest(string QuizId, string PasserId, int Mark);
}
