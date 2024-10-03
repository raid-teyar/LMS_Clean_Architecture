namespace Domain.Enums;

public enum ReservationStatus
{
    Pending, // Default status
    Notified, // User has been notified that the book is available
    Completed, // User has picked up the book
    Expired // User did not pick up the book in time
}