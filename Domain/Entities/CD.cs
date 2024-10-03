using Domain.Aggregates;
using Domain.ValueObjects;

namespace Domain.Entities;

public class CD : LibraryMaterial
{
    public string Artist { get; private set; }
    public string Duration { get; private set; }

    public CD(
        string title, 
        string artist,
        string duration,
        bool isLoanable = true) : base(title, null, isLoanable)
    {
        Artist = artist;
        Duration = duration;
    }
}