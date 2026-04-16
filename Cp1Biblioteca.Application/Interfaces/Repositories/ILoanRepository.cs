using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Application.Interfaces.Repositories;

public interface ILoanRepository
{
    IReadOnlyCollection<Loan> GetAll();
    Loan? GetById(int id);
    void Add(Loan entity);
    void Update(Loan entity);
    void Delete(Loan entity);
    void SaveChanges();
}