using Domain.QuizAggregate;
using Domain.QuizAggregate.ValueObjects;
using Application.Common.Specifications;

namespace Application.Common.Interfaces.Persistence
{
    public interface IQuizRepository
    {
        Task<Quiz> AddQuizAsync(Quiz quiz);
        Task RemoveQuizAsync(Quiz quiz);
        Task<List<Quiz>> GetQuizzesAsync(Specification specification);
        Task<Quiz?> GetQuizAsync(QuizId quizId);
        Task UpdateQuizAsync(Quiz quiz);
    }
}
