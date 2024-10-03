namespace Domain.Exceptions;

public class LoanAlreadyReturnedException : Exception
{
    public LoanAlreadyReturnedException(string message)
        : base(message)
    {
    }
}