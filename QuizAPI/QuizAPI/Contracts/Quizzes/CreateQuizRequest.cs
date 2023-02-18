namespace Presentation.Api.Contracts.Quizzes
{
    public record CreateQuizRequest(
        string Name,
        string Description,
        byte Difficulty,
        List<QuestionRequest> Questions);

    public record QuestionRequest(
        string Title,
        List<AnswerRequest> Answers,
        byte CorrectAnswer);

    public record AnswerRequest(
        string Title);

}
