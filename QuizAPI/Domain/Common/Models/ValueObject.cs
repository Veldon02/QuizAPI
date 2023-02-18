namespace Domain.Common.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) return false;

            return ReferenceEquals(left, right) || left!.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents()
                .SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }
    }
}
