namespace Domain.Services;

public class LoanManagementService : ILoanManagementService
{
    private readonly ILoanRepository _loanRepository;

    public LoanManagementService(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }
    
    // this method should be called by a scheduler in the application layer
    public void CheckOverdueLoans()
    {
        var loans = _loanRepository.GetAllActiveLoans();
        
        foreach (var loan in loans)
        {
            // check if loan is overdue
            if (!loan.IsOverdueMoreThan(0)) continue;
            
            // add alert
            loan.AddAlert();
                
            // Check if the loan is overdue by more than 3 days
            if (loan.IsOverdueMoreThan(3))
            {
                // Ban User for 5 days
                loan.User.ApplySanction(5);
            }

        }
    }
}