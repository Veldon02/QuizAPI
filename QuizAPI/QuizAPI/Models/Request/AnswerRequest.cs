using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Request
{
    public class AnswerRequest
    {
        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
    }
}
