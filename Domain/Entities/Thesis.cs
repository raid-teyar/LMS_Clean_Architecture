using Domain.ValueObjects;

namespace Domain.Entities;

public class Thesis : AcademicWork
{
    public string ResearchTopic { get; private set; }

    public Thesis(
        string title,
        string[] authors,
        string[] supervisors,
        int year,
        string department,
        string researchTopic,
        bool isLoanable = true) : base(title, authors, supervisors, year, department, isLoanable)
    {
        ResearchTopic = researchTopic;
    }
}