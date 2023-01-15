using QuizAPI.Models;

namespace QuizAPI.ViewModels
{
    public class AuthResultVM
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string RefreshToken{ get; set; }
    }
}
