using Domain.AuthorAggregate;
using Domain.AuthorAggregate.ValueObjects;

namespace Application.Common.Interfaces.Persistence
{
    public interface IAuthorRepository
    {
        Task<Author?> GetAsync(AuthorId authorId);
        Task<Author> AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task RemoveAsync(Author author);
    }
}
