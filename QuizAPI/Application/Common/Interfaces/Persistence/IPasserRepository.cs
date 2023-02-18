using Domain.PasserAggregate;
using Domain.PasserAggregate.ValueObjects;

namespace Application.Common.Interfaces.Persistence
{
    public interface IPasserRepository
    {
        Task<Passer?> GetAsync(PasserId authorId);
        Task<Passer> AddAsync(Passer author);
        Task UpdateAsync(Passer author);
        Task RemoveAsync(Passer author);
    }
}
