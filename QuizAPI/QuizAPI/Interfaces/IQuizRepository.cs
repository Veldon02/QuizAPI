using QuizAPI.Models;

namespace QuizAPI.Interfaces
{
    public interface IQuizRepository
    {
        public Task<Quiz> GetQuizAsync(int id);
        public Task<IEnumerable<Quiz>> GetQuizzesAsync(QuerySpecification querySpecification);      
        public Task<Quiz> CreateQuizAsync(Quiz quiz); 
        public Task<Subject> GetSubjectAsync(string subject);
        public Task<Subject> GetSubjectAsync(int id);
        
    }
}
