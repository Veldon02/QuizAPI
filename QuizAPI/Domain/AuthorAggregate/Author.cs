using Domain.AuthorAggregate.ValueObjects;
using Domain.Common.Models;
using Domain.QuizAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AuthorAggregate
{
    public sealed class Author : AggregateRoot<AuthorId>
    {
        private readonly List<QuizId> _quizIds = new();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Author() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Author(AuthorId id, UserId userId, List<QuizId> quizIds) : base(id)
        {
            UserId = userId;
            _quizIds = quizIds;
        }
        public UserId UserId { get; private set; }
        public IReadOnlyList<QuizId> QuizIds => _quizIds.AsReadOnly();

        public static Author Create(UserId userId, List<QuizId> quizIds)
        {
            return new Author(AuthorId.Create(userId), userId, quizIds);
        }
    }
}
