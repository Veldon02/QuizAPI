using Domain.Common.Models;
using Domain.MarkAggregate.ValueObjects;
using Domain.PasserAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;

namespace Domain.PasserAggregate
{
    public sealed class Passer : AggregateRoot<PasserId>
    {
        private readonly List<MarkId> _markIds = new();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Passer() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Passer(PasserId id, UserId userId, List<MarkId> markIds) : base(id)
        {
            UserId = userId;
            _markIds = markIds;
        }
        public UserId UserId { get; private set; }
        public IReadOnlyList<MarkId> MarkIds => _markIds.AsReadOnly();
        public static Passer Create(UserId userId, List<MarkId> markIds)
        {
            return new(PasserId.Create(userId), userId, markIds);
        }
    }
}
