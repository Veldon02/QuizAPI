using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [MaxLength(400)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public byte QuestionCount { get; set; }
        [Required]
        public byte Difficulty { get; set; }
        [Required]
        public string AuthorId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public IEnumerable<Mark> Marks { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
