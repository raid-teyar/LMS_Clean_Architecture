using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using Domain.Events;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public abstract class LibraryMaterial : AggregateBase
{
    public string Title { get; protected set; }
    public ISBN? ISBN { get; protected set; } // it's nullable because some materials may not have an ISBN (e.g. CDs, Theses, Dissertations)
    public bool IsLoanable { get; protected set; }
    
    protected LibraryMaterial(string title, ISBN? isbn, bool isLoanable)
    {
        Title = title;
        ISBN = isbn;
        IsLoanable = isLoanable;
        
        // I kept LibraryMaterial as an aggregate because it needs to be able to raise events
        AddDomainEvent(new LibraryMaterialCreatedEvent(this));
    }
    
    public virtual bool CanBeBorrowed()
    {
        return IsLoanable;
    }
}