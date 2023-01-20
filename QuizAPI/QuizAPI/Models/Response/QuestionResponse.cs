namespace QuizAPI.Models.Response
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<AnswerResponse> Answers { get; set; }
    }
}
