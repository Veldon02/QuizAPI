namespace Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
        where TId : notnull
    {
        public TId Id { get; private set; }

        protected Entity(TId id)
        {
            Id = id;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;

            var other = (Entity<TId>)obj;

            return Id.Equals(other.Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool EqualsOperation(Entity<TId> left, Entity<TId> right)
        {
            return left.Equals(right);
        }
        public static bool NotEqualsOperation(Entity<TId> left, Entity<TId> right)
        {
            return !left.Equals(right);
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Entity()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
