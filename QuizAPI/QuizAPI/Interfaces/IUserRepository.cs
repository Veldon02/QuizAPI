using QuizAPI.Models;

namespace QuizAPI.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserByIdAsync(string id);
    }
}
