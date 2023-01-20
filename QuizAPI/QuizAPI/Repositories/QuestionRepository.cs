using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.Interfaces;
using QuizAPI.Models;

namespace QuizAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;

        public QuestionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<QuestionAnswer> CreateQuastionAnswerAsync(int questionId, int answerId)
        {
            var questionAnswer = new QuestionAnswer()
            {
                QuestionId = questionId,
                AnswerId = answerId
            };

            _context.QuestionAnswers.Add(questionAnswer);
            await _context.SaveChangesAsync();

            return questionAnswer;
        }

        public async Task<Question> CreateQuastionAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Answer> GetAnswerAsync(int id)
        {
            return await _context.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Answer>> GetAnswersAsync(int questionId)
        {
            var answers = await _context.Answers
                .Where(x => x.QuestionId == questionId)
                .ToListAsync();

            return answers;
        }

        public async Task<QuestionAnswer> GetQuestionAnswerAsync(int questionId)
        {
            return await _context.QuestionAnswers.FirstOrDefaultAsync(x => x.QuestionId == questionId);
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _context.Questions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync(int quizId)
        {
            var questions = await _context.Questions
                .Where(x => x.QuizId == quizId)
                .ToListAsync();

            return questions;
        }
    }
}
