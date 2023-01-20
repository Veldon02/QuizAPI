using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Request
{
    public class MarkRequest
    {
        [Required]
        public int QuizId { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public byte Mark { get; set; }
    }
}
