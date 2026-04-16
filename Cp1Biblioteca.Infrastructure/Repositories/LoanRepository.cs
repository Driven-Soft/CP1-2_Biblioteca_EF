namespace Cp1Biblioteca.Infrastructure.Repositories;

using Cp1Biblioteca.Application.Interfaces.Repositories;
using Cp1Biblioteca.Entities;
using Cp1Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class LoanRepository : ILoanRepository
{
    private readonly BibliotecaContext _context;
    public LoanRepository(BibliotecaContext context) => _context = context;

    public IReadOnlyCollection<Loan> GetAll() =>
        _context.Loans
            .Include(l => l.Book)
            .Include(l => l.User)
            .ToList();

    public Loan? GetById(int id) =>
        _context.Loans
            .Include(l => l.Book)
            .Include(l => l.User)
            .FirstOrDefault(l => l.Id == id);

    public void Add(Loan entity) => _context.Loans.Add(entity);
    public void Update(Loan entity) => _context.Loans.Update(entity);
    public void Delete(Loan entity) => _context.Loans.Remove(entity);
    public void SaveChanges() => _context.SaveChanges();
}
