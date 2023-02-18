using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QuizAggregate.ValueObjects
{
    public sealed class QuestionId : ValueObject
    {
        public Guid Value { get; }
        private QuestionId(Guid value)
        {
            Value = value;
        }
        public static QuestionId CreateUnique()
        {
            return new QuestionId(Guid.NewGuid());
        }
        public static QuestionId Create(Guid questionId)
        {
            return new QuestionId(questionId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
