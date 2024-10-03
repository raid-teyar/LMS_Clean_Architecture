using Domain.Aggregates;
using Domain.Common;

namespace Domain.Events;

public class UserSanctionedEvent : DomainEvent
{
    public User User { get; set; }
    public int DurationInDays { get; set; }

    public UserSanctionedEvent(User user, int duration)
    {
        User = user;
        DurationInDays = duration;
    }
    
}