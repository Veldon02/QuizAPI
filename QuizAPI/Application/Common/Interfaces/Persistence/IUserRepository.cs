using Domain.UserAggregate;
using Domain.UserAggregate.ValueObjects;

namespace Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(UserId userId);
        Task RemoveAsync(User user);
    }
}
