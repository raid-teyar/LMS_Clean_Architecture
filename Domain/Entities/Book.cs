using Domain.Aggregates;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Book : LibraryMaterial
{
    public BookType Category { get; private set; }
    public string Author { get; private set; }
    public string Publisher { get; private set; }
    public int PublicationYear { get; private set; }
    
    public Book(
        string title, 
        ISBN isbn, 
        BookType category,
        string author,
        string publisher,
        int publicationYear,
        bool isLoanable = true) : base(title, isbn, isLoanable)
    {
        Category = category;
        Author = author;
        Publisher = publisher;
        PublicationYear = publicationYear;
    }
}