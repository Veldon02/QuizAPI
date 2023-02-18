namespace Presentation.Api.Contracts.Quizzes
{

    public record UpdateQuizInfoRequest(
        string Name,
        string Description,
        byte Difficulty);
}
