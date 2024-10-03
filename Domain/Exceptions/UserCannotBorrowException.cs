namespace Domain.Exceptions;

public class UserCannotBorrowException : Exception
{
    public UserCannotBorrowException(string message)
        : base(message)
    {
    }
}