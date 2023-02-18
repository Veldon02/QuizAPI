using Domain.Common.Models;
using Domain.MarkAggregate.ValueObjects;
using Domain.PasserAggregate.ValueObjects;
using Domain.QuizAggregate.ValueObjects;


namespace Domain.MarkAggregate
{
    public sealed class Mark : AggregateRoot<MarkId>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Mark() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Mark(MarkId markId,
                     int passerMark,
                     QuizId quizId,
                     PasserId passerId) : base(markId)
        {
            PasserMark = passerMark;
            QuizId = quizId;
            PasserId = passerId;
            CreatedTime = DateTime.Now;
        }

        public static Mark Create(int passerMark,
                                  QuizId quizId,
                                  PasserId passerId)
        {
            return new Mark(MarkId.CreateUnique(),
                            passerMark,
                            quizId,
                            passerId);
        }

        public int PasserMark { get; private set; }
        public QuizId QuizId { get; private set; }
        public PasserId PasserId { get; private set; }
        public DateTime CreatedTime { get; private set; }
    }
}
