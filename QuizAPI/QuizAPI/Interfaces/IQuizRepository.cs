using QuizAPI.Models;

namespace QuizAPI.Interfaces
{
    public interface IQuizRepository
    {
        public Task<Quiz> GetQuizAsync(int id);
        public Task<IEnumerable<Quiz>> GetQuizzesAsync(QuerySpecification querySpecification);
        public Task<Mark> GetMarkAsync(string userId, int quizId);
        public Task<IEnumerable<Mark>> GetMarksAsync(string userId);
        public Task<IEnumerable<Mark>> GetMarksAsync(int quizId);
        public Task<Quiz> CreateQuizAsync(Quiz quiz);
        public Task<Question> CreateQuastionAsync(Question question, int correctAnswer);
        public Task<Answer> CreateAnswerAsync(Answer answer);
    }
}
