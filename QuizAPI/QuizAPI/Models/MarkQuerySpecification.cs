namespace QuizAPI.Models
{
    public class MarkQuerySpecification:QuerySpecification
    {
        public int QuizId { get; set; }
        public string UserEmail { get; set; }

        public bool Sorted { get; set; } = false;

        public bool SortByMarkAsc { get; set; } = true;
    }
}
