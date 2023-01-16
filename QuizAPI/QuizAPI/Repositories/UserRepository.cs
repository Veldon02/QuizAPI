using Microsoft.AspNetCore.Identity;
using QuizAPI.Interfaces;
using QuizAPI.Models;

namespace QuizAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
    }
}
