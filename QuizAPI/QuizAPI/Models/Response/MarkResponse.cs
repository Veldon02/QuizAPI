namespace QuizAPI.Models.Response
{
    public class MarkResponse
    {
        public int QuizId { get; set; }
        public string UserEmail { get; set; }
        public byte Mark { get; set; }
        public byte MaxMark { get; set; }
    }
}
