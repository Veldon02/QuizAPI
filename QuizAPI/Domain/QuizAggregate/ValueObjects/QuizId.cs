using Domain.Common.Models;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QuizAggregate.ValueObjects
{
    public sealed class QuizId : ValueObject
    {
        private readonly static string pattern = @"[A-Z0-9]{10}";
        public string Value { get; }

        public QuizId(string value)
        {
            Value = value;
        }

        public static QuizId CreateUnique()
        {
            return new(RegexGenerator.Generate(pattern));
        }

        public static QuizId Create(string quizId)
        {
            return new(quizId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
