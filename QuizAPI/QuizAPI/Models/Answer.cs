using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public QuestionAnswer questionAnswer { get; set; }
        [Required]
        public int QuestionId { get; set; }
    }
}
