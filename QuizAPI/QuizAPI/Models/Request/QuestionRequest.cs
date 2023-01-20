using QuizAPI.Models.Response;
using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Request
{
    public class QuestionRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public IEnumerable<AnswerRequest> Answers { get; set; }
        [Required]
        public int CorrectAnswer { get; set; }
    }
}
