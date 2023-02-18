using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MarkAggregate.ValueObjects
{
    public sealed class MarkId : ValueObject
    {
        private MarkId() { }
        public Guid Value { get; }
        private MarkId(Guid value)
        {
            Value = value;
        }
        public static MarkId CreateUnique()
        {
            return new MarkId(Guid.NewGuid());
        }
        public static MarkId Create(Guid value)
        {
            return new MarkId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
