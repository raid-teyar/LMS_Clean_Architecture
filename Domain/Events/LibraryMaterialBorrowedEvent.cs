using Domain.Aggregates;
using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class LibraryMaterialBorrowedEvent : DomainEvent
{
    public User User { get; }
    public Loan Loan { get; }
    public LibraryMaterialBorrowedEvent(User user, Loan loan)
    {
        User = user;
        Loan = loan;
    }
}