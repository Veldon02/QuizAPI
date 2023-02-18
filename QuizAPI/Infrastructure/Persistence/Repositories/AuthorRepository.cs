using Application.Common.Interfaces.Persistence;
using Domain.AuthorAggregate;
using Domain.AuthorAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly QuizDbContext _context;

        public AuthorRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<Author> AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> GetAsync(AuthorId authorId)
        {
            return await _context.Authors.FirstOrDefaultAsync(x => x.Id == authorId);
        }

        public async Task RemoveAsync(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
