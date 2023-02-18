namespace Presentation.Api.Contracts.Quizzes
{
    public record AddQuestionRequest(
        string Title, 
        List<AnswerRequest> Answers,
        byte CorrectAnswer);

    
}
