namespace Presentation.Api.Contracts.Quizzes
{
    public record MarkResponse(
        string QuizId,
        string PasserId,
        int Mark,
        DateTime ReceiptDate);
}
