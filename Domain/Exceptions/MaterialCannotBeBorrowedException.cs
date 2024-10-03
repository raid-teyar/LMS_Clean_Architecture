namespace Domain.Exceptions;

public class MaterialCannotBeBorrowedException : Exception
{
    public MaterialCannotBeBorrowedException(string message)
        : base(message)
    {
    }
}