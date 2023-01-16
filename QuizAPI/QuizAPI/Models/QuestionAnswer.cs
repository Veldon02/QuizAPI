using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models
{
    public class QuestionAnswer
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int AnswerId { get; set; }
    }
}
