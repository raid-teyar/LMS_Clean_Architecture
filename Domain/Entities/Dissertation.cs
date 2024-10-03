using Domain.Aggregates;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Dissertation : AcademicWork
{
    public string Field { get; private set; }

    public Dissertation(
        string title,
        string[] authors,
        string[] supervisors,
        int year,
        string department,
        string field,
        bool isLoanable = true) : base(title, authors, supervisors, year, department, isLoanable)
    {
        Field = field;
    }
}