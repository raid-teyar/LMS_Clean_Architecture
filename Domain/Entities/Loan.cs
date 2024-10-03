using Domain.Aggregates;
using Domain.Common;
using Domain.Events;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Loan : AggregateBase
{
    private const int DefaultLoanPeriod = 15;
    public User User { get; private set; }
    public LibraryMaterial LibraryMaterial { get; private set; }
    public LoanPeriod Period { get; private set; }
    
    private readonly List<Alert> _alerts;
    public IReadOnlyCollection<Alert> Alerts => _alerts.AsReadOnly();
 
    internal Loan(User user, LibraryMaterial libraryMaterial)
    {
        User = user;
        LibraryMaterial = libraryMaterial;
        Period = new LoanPeriod(DateTime.Now, DefaultLoanPeriod);
        _alerts = new List<Alert>();
    }
    
    public bool IsReturned() => Period.ReturnDate.HasValue;
    
    public void Return(DateTime returnDate)
    {
        if (IsReturned())
            throw new LoanAlreadyReturnedException("Loan already returned");

        Period.Return(returnDate);
    }
    
    public bool IsOverdueMoreThan(int days)
    {
        return !IsReturned() && Period.GetOverdueDays(DateTime.Now) > days;
    }

    // TODO: 2nd added business rule (loan renewing)
    public bool Renew()
    {
        if (IsReturned())
            throw new LoanAlreadyReturnedException("Loan already returned");

        if (Period.GetOverdueDays(DateTime.Now) > 0)
            throw new LoanOverdueException("Loan is overdue");

        Period.Renew();
        return true;
    }
        
    
    internal void AddAlert()
    {
        if (!IsReturned() && DateTime.Now > Period.DueDate)
        {
            Alert alert = new Alert(this);
            _alerts.Add(alert);
            
            AddDomainEvent(new AlertCreatedEvent(this));
        }
    }
}