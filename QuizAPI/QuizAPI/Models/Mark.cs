using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models
{
    public class Mark
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        public int QuizId { get; set; }
        [Required]
        public byte QuizMark { get; set; }
    }
}
