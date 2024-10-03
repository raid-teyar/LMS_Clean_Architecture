using Domain.Common;

namespace Domain.Entities;

public class Alert : EntityBase
{
    public Loan Loan { get; private set; }
    public DateTime AlertDate { get; private set; }

    internal Alert(Loan loan)
    {
        Loan = loan;
        AlertDate = DateTime.Now;
    }
}