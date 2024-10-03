namespace Domain.ValueObjects;

public record Money
{
    public decimal Amount { get; }
    public string Currency { get; }
    
    public Money(decimal amount, string currency = "USD")
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative");
        
        Amount = amount;
        Currency = currency;
    }

    // overriding the + operator to add two Money objects
    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new ArgumentException("Cannot add money with different currencies");
        
        return new Money(a.Amount + b.Amount, a.Currency);
    }
}