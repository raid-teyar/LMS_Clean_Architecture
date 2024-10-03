using Domain.Entities;

namespace Domain.Services;

public interface ILoanRepository
{
    Loan GetById(Guid loanId);
    IEnumerable<Loan> GetAllActiveLoans();
    void Add(Loan loan);
    void Update(Loan loan);
    void Remove(Loan loan);
}