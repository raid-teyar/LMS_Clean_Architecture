namespace Domain.ValueObjects;

public record ISBN // chose it to be a value object because it needs to be validated
{
    public string Value { get; }
    
    public ISBN(string value)
    {
       if (string.IsNullOrWhiteSpace(value))
           throw new ArgumentException("ISBN cannot be empty");
       
       // we should add ISBN validation logic here
       Value = value;
    }
}