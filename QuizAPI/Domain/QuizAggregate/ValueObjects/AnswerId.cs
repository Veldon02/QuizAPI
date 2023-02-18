using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QuizAggregate.ValueObjects
{
    public sealed class AnswerId : ValueObject
    {
        public Guid Value { get; }
        private AnswerId(Guid value)
        {
            Value = value;
        }
        public static AnswerId CreateUnique()
        {
            return new AnswerId(Guid.NewGuid());
        }
        public static AnswerId Create(Guid answerId)
        {
            return new AnswerId(answerId);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
