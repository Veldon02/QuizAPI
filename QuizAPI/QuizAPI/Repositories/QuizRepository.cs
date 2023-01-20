using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.Interfaces;
using QuizAPI.Models;

namespace QuizAPI.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly DataContext _context;

        public QuizRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Quiz> CreateQuizAsync(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        public async Task<Mark> GetMarkAsync(string userId, int quizId)
        {
            return await _context.Marks.FirstOrDefaultAsync(x => x.UserId == userId && x.QuizId == quizId);
        }

        public async Task<IEnumerable<Mark>> GetMarksAsync(string userId)
        {
            return await _context.Marks
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mark>> GetMarksAsync(int quizId)
        {
            return await _context.Marks
                .Where(x => x.QuizId == quizId)
                .ToListAsync();
        }

        public async Task<Quiz> GetQuizAsync(int id)
        {
            return await _context.Quizzes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Quiz>> GetQuizzesAsync(QuerySpecification querySpecification)
        {
            IQueryable<Quiz> quizzes = _context.Quizzes;

            quizzes = quizzes
                .Skip((querySpecification.Page-1)*querySpecification.Size)
                .Take(querySpecification.Size);

            return await quizzes.ToListAsync();
        }

        public async Task<Subject> GetSubjectAsync(string subject)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.Name == subject);
        }

        public async Task<Subject> GetSubjectAsync(int id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
