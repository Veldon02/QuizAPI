using QuizAPI.Models;

namespace QuizAPI.Interfaces
{
    public interface IMarkRepository
    {
        public Task<Mark> CreateMarkAsync(Mark mark);
        public Task<IEnumerable<Mark>> GetMarkAsync(int quizId, string email);
        public Task<Mark> GetMarksAsync(MarkQuerySpecification querySpecification);
    }
}
