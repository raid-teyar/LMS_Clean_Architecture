namespace Domain.Exceptions;

public class LoanOverdueException : Exception
{
    public LoanOverdueException(string message)
        : base(message)
    {
    }
}