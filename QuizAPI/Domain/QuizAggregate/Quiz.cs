using Domain.AuthorAggregate.ValueObjects;
using Domain.Common.Models;
using Domain.QuizAggregate.Entities;
using Domain.QuizAggregate.ValueObjects;


namespace Domain.QuizAggregate
{
    public sealed class Quiz : AggregateRoot<QuizId>
    {
        private readonly List<Question> _questions = new();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Quiz() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Quiz(QuizId quizId,
                     string name,
                     string description,
                     byte difficulty,
                     AuthorId authorId,
                     List<Question> questions) : base(quizId)
        {
            Name = name;
            Description = description;
            Difficulty = difficulty;
            AuthorId = authorId;
            _questions = questions;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public static Quiz Create(string name,
                     string description,
                     byte difficulty,
                     AuthorId authorId,
                     List<Question> questions)
        {
            return new Quiz(QuizId.CreateUnique(), name, description, difficulty, authorId, questions);
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public byte Difficulty { get; private set; }
        public AuthorId AuthorId { get; private set; }
        public IReadOnlyList<Question> Questions => _questions.AsReadOnly();
        public DateTime UpdatedDate { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public void Update(string name, string description, byte difficulty)
        {
            Name = name;
            Description = description;
            Difficulty = difficulty;
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }

        public void RemoveQuestion(QuestionId questionId)
        {
            var question = _questions.FirstOrDefault(x => x.Id == questionId);
            _questions.Remove(question);
        }

    }
}
