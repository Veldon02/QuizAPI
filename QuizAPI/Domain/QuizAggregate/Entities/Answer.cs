using Domain.Common.Models;
using Domain.QuizAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QuizAggregate.Entities
{
    public sealed class Answer : Entity<AnswerId>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Answer() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Answer(AnswerId id, string title) : base(id)
        {
            Title = title;
        }

        public static Answer Create(string title)
        {
            return new Answer(AnswerId.CreateUnique(), title);
        }
        public string Title { get; }
    }
}
