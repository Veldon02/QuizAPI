using Domain.Common.Models;
using Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasserAggregate.ValueObjects
{
    public sealed class PasserId : ValueObject
    {
        public string Value { get; }
        private PasserId(string value)
        {
            Value = value;
        }
        public static PasserId Create(UserId userId)
        {
            return new PasserId($"Passer_{userId.Value}");
        }
        public static PasserId Create(string passerId)
        {
            return new PasserId(passerId);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
