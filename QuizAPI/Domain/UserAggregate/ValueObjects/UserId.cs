using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserAggregate.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; }
        private UserId(Guid id)
        {
            Value = id;
        }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }
        public static UserId Create(Guid id)
        {
            return new UserId(id);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
