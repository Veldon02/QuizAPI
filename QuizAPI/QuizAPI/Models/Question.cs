using System.ComponentModel.DataAnnotations;

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

        public Quiz Quiz { get; set; }
    }
}
