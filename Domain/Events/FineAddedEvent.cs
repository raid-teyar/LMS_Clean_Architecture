using Domain.Aggregates;
using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Events;

public class FineAddedEvent : DomainEvent
{
    public User User { get; set; }
    public Money Amount { get; set; }

    public FineAddedEvent(User user, Money amount)
    {
        User = user;
        Amount = amount;
    }
    
}