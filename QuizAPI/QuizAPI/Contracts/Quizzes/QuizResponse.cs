namespace Presentation.Api.Contracts.Quizzes
{
    public record QuizResponse
    (string Id,
     string Name,
     string Description,
     byte Difficulty,
     string AuthorId,
     List<Guid> QuestionIds);

    public record QuestionResponse
    (Guid Id,
     string Title,
     List<AnswerResponse> Answers,
     Guid CorrectAnswer);

    public record AnswerResponse
    (Guid Id,
     string Title);
}

