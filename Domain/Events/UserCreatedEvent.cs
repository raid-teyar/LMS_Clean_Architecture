using Domain.Aggregates;
using Domain.Common;

namespace Domain.Events;

public class UserCreatedEvent : DomainEvent
{
    public User User { get; }
    public UserCreatedEvent(User user) => User = user;
}