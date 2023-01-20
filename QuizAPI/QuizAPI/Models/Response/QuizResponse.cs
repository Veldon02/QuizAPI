using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Response
{
    public class QuizResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public byte QuestionCount { get; set; }
        public byte Difficulty { get; set; }
        public UserResponse Author { get; set; }
        public string Subject { get; set; }
        public IEnumerable<int> Questions { get; set; }
    }
}
