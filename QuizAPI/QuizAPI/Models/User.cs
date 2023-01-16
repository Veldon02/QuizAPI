using Microsoft.AspNetCore.Identity;

namespace QuizAPI.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Quiz> Quizzes { get; set; }

        public IEnumerable<Mark> Marks { get; set; }
    }
}
