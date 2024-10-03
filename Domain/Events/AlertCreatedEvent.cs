using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class AlertCreatedEvent : DomainEvent
{
    public Loan Loan { get; }

    public AlertCreatedEvent(Loan loan)
    {
        Loan = loan;
    }
    
}