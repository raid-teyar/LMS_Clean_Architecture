namespace Domain.ValueObjects;

public record class LoanPeriod
{
    public DateTime StartDate { get; }
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    
    public LoanPeriod(DateTime startDate, int durationInDays)
    {
        StartDate = startDate;
        DueDate = startDate.AddDays(durationInDays);
    }

    public void Return(DateTime returnDate)
    {
        if (returnDate < StartDate)
            throw new ArgumentException("Return date cannot be before start date");

        ReturnDate = returnDate;
    }

    public int? GetOverdueDays(DateTime currentDate)
    {
        if (ReturnDate.HasValue)
            return ReturnDate.Value > DueDate ? (ReturnDate.Value - DueDate).Days : 0;
            
        return currentDate > DueDate ? (currentDate - DueDate).Days : 0;
    }
    
    public void Renew()
    {
        DueDate = DueDate.AddDays(15);
    }
}