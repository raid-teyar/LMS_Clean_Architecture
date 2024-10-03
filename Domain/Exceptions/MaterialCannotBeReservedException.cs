namespace Domain.Exceptions;

public class MaterialCannotBeReservedException: Exception
{
    public MaterialCannotBeReservedException(string message)
        : base(message)
    {
        
    }
}