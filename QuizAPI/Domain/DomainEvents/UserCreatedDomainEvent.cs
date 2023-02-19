using Domain.Common.Interfaces;
using Domain.UserAggregate.ValueObjects;

namespace Domain.DomainEvents
{
    public record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;
    //TODO: Implement UnitOfWork with meadiatr publisher inside, which will raise events after transatcion ended
}
