using QuizAPI.Models.Response;
using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Request
{
    public class QuizRequest
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public byte Difficulty { get; set; }
        [Required]
        public string AuthorEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public IEnumerable<QuestionRequest> Questions { get; set; }
    }
}
