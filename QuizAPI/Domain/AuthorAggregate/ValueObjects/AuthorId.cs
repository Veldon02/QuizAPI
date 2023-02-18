using Domain.Common.Models;
using Domain.UserAggregate.ValueObjects;

namespace Domain.AuthorAggregate.ValueObjects
{
    public sealed class AuthorId : ValueObject
    {
        public string Value { get; }

        private AuthorId(string value)
        {
            Value = value;
        }

        public static AuthorId Create(UserId userId)
        {
            return new AuthorId($"Author_{userId.Value}");
        }
        public static AuthorId Create(string passerId)
        {
            return new AuthorId(passerId);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
