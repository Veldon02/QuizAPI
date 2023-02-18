using Domain.Common.Models;
using Domain.QuizAggregate.ValueObjects;

namespace Domain.QuizAggregate.Entities
{
    public sealed class Question : Entity<QuestionId>
    {
        private readonly List<Answer> _answers = new();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Question() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Question(QuestionId id, string title, byte correctAnswer, List<Answer> asnwers) : base(id)
        {
            Title = title;
            CorrectAnswer = correctAnswer;
            _answers = asnwers;
        }
        public static Question Create(string title, byte correctAnswer, List<Answer> answers)
        {
            return new Question(QuestionId.CreateUnique(), title, correctAnswer,answers);
        }

        public string Title{ get; }
        public byte CorrectAnswer { get; }
        public List<Answer> Answers => _answers.ToList();
    }
}
