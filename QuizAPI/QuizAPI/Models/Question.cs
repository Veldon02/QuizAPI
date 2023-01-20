using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAPI.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public IEnumerable<Answer> Answers { get; set; }
        [Required]
        public QuestionAnswer questionAnswer { get; set; }
        public int QuizId { get; set; }
    }
}
