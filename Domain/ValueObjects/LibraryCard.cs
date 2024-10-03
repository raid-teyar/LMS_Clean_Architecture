namespace Domain.ValueObjects;

public record LibraryCard
{
    public string UniqueCode { get; }
    public DateTime IssueDate { get; }
    public DateTime ExpiryDate { get; }

    public LibraryCard(string uniqueCode, DateTime issueDate, DateTime expiryDate)
    {
        if (string.IsNullOrWhiteSpace(uniqueCode))
            throw new ArgumentException("Library card code cannot be empty");

        UniqueCode = uniqueCode;
        IssueDate = issueDate;
        ExpiryDate = expiryDate;
    }
}