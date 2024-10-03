using Domain.Aggregates;
using Domain.ValueObjects;

namespace Domain.Entities;

public class AcademicWork : LibraryMaterial
{
    public string[] Authors { get; private set; }
    public string[] Supervisors { get; private set; }
    public int Year { get; private set; }
    public string Department { get; private set; }
    
    protected AcademicWork(
        string title,
        string[] authors,
        string[] supervisors,
        int year,
        string department,
        bool isLoanable = true) : base(title, null, isLoanable)
    {
        Authors = authors;
        Supervisors = supervisors;
        Year = year;
        Department = department;
    }
}