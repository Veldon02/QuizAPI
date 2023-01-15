using System.ComponentModel.DataAnnotations;

namespace QuizAPI.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string FisrtName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
