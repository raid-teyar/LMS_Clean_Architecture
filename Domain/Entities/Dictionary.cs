using Domain.Aggregates;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Dictionary : LibraryMaterial
{
    public string Language { get; private set; }
    public int Edition { get; private set; }

    public Dictionary(
        string title, 
        ISBN isbn, 
        string language,
        int edition,
        bool isLoanable = true) : base(title, isbn, isLoanable)
    {
        Language = language;
        Edition = edition;
    }
}