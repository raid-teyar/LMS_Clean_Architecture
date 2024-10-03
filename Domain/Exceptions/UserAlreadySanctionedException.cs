namespace Domain.Exceptions;

public class UserAlreadySanctionedException : Exception
{
    public UserAlreadySanctionedException(int userId)
        : base($"User with ID {userId} is already sanctioned.")
    {
    }
    
}