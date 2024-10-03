using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using Domain.Events;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class User : AggregateBase
{
    public string Name { get; set; }
    public LibraryCard Card { get; set; }
    public UserType UserType { get; set; }
    public Money FineBalance { get; set; }
    public DateTime? SanctionEndDate { get; set; }
    
    private readonly List<Loan> _loans;
    public IReadOnlyCollection<Loan> Loans => _loans.AsReadOnly();
    
    
    public User(string name, LibraryCard card, UserType type)
    {
        Name = name;
        Card = card;
        UserType = type;
        FineBalance = new Money(0);
        _loans = new List<Loan>();
            
        AddDomainEvent(new UserCreatedEvent(this));
    }
    
    public bool CanBorrow()
    {
        return _loans.Count(l => !l.IsReturned()) < 5 &&
               (SanctionEndDate == null || SanctionEndDate < DateTime.Now) &&
               FineBalance.Amount == 0;
    }
    
    public Loan Borrow(LibraryMaterial material)
    {
        if (!CanBorrow())
            throw new UserCannotBorrowException("User cannot borrow");
        
        if(!material.CanBeBorrowed())
            throw new MaterialCannotBeBorrowedException("Material cannot be borrowed");
        
        var loan = new Loan(this, material);
        _loans.Add(loan);
        
        AddDomainEvent(new LibraryMaterialBorrowedEvent(this, loan));
        return loan;
    }
    
    public void AddFine(Money fine)
    {
        FineBalance += fine;
        AddDomainEvent(new FineAddedEvent(this, fine));
    }
    
    public void ApplySanction(int durationInDays)
    {
        // TODO: 1st added business rule (A user cannot have more than one active sanction at any given time)
        if (SanctionEndDate != null && SanctionEndDate > DateTime.Now)
            throw new UserAlreadySanctionedException(Id);
        
        SanctionEndDate = DateTime.Now.AddDays(durationInDays);
        AddDomainEvent(new UserSanctionedEvent(this, durationInDays));
    }
}