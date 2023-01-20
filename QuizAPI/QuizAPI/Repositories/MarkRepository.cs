using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.Interfaces;
using QuizAPI.Models;

namespace QuizAPI.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;

        public MarkRepository(DataContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        public async Task<Mark> CreateMarkAsync(Mark mark)
        {
            _context.Marks.Add(mark);
            await _context.SaveChangesAsync();
            return mark;
        }

        public async Task<IEnumerable<Mark>> GetMarkAsync(int quizId, string email)
        {
            IQueryable <Mark> marks = _context.Marks;

            var user = await _userRepository.GetUserByEmailAsync(email);

            marks = marks
                .Where(x => x.QuizId == quizId && x.UserId == user.Id);

            return await marks.ToListAsync();
        }

        public Task<Mark> GetMarksAsync(MarkQuerySpecification querySpecification)
        {
            throw new NotImplementedException();
        }
    }
}
