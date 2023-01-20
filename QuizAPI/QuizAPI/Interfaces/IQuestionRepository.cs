using QuizAPI.Models;

namespace QuizAPI.Interfaces
{
    public interface IQuestionRepository
    {
        public Task<Question> CreateQuastionAsync(Question question);
        public Task<QuestionAnswer> CreateQuastionAnswerAsync(int questionId, int answerId);
        public Task<Answer> CreateAnswerAsync(Answer answer);
        public Task<IEnumerable<Question>> GetQuestionsAsync(int quizId);
        public Task<IEnumerable<Answer>> GetAnswersAsync(int questionId);
        public Task<Question> GetQuestionAsync(int id);
        public Task<Answer> GetAnswerAsync(int id);

        public Task<QuestionAnswer> GetQuestionAnswerAsync(int questionId);
    }
}
