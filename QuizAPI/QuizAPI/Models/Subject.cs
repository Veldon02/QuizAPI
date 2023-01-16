using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
