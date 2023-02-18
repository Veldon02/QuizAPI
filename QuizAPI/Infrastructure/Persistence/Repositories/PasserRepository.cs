using Application.Common.Interfaces.Persistence;
using Domain.PasserAggregate;
using Domain.PasserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PasserRepository : IPasserRepository
    {
        private readonly QuizDbContext _context;

        public PasserRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<Passer> AddAsync(Passer author)
        {
            _context.Passers.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Passer?> GetAsync(PasserId authorId)
        {
            return await _context.Passers.FirstOrDefaultAsync(x => x.Id == authorId);
        }

        public async Task RemoveAsync(Passer author)
        {
            _context.Passers.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Passer author)
        {
            _context.Passers.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
