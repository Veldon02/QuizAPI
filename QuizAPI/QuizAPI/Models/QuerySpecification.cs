namespace QuizAPI.Models
{
    public class QuerySpecification
    {
        private const int _maxSize = 100;
        private int _size = 20;
        public int Page { get; set; } = 1;
        public int Size { 
            get { return _size; }
            set { _size = Math.Min(_maxSize, value); } 
        }
    }
}
