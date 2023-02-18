using Application.Common.Interfaces.Persistence;
using Application.Common.Specifications;
using Domain.QuizAggregate;
using Domain.QuizAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizDbContext _context;

        public QuizRepository(QuizDbContext context)
        {
            _context = context;
        }
        public async Task<Quiz> AddQuizAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        public async Task<List<Quiz>> GetQuizzesAsync(Specification specification)
        {
            IQueryable<Quiz> query = _context.Quizzes;
            return await query
                .Skip(specification.PageSize * (specification.Page - 1))
                .Take(specification.PageSize)
                .ToListAsync();
        }

        public async Task<Quiz?> GetQuizAsync(QuizId quizId)
        {
            return await _context.Quizzes.FirstOrDefaultAsync(x => x.Id == quizId);
        }

        public async Task RemoveQuizAsync(Quiz quiz)
        {
            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
        }
    }
}
