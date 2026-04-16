namespace Cp1Biblioteca.Infrastructure.Repositories;

using Cp1Biblioteca.Application.Interfaces.Repositories;
using Cp1Biblioteca.Entities;
using Cp1Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly BibliotecaContext _context;
    public UserRepository(BibliotecaContext context) => _context = context;

    public IReadOnlyCollection<User> GetAll() =>
        _context.Users.Include(u => u.Loans).ToList();

    public User? GetById(int id) =>
        _context.Users.Include(u => u.Loans).FirstOrDefault(u => u.Id == id);

    public User? GetByEmail(string email) =>
        _context.Users.FirstOrDefault(u => u.Email == email);

    public void Add(User entity) => _context.Users.Add(entity);
    public void Update(User entity) => _context.Users.Update(entity);
    public void Delete(User entity) => _context.Users.Remove(entity);
    public void SaveChanges() => _context.SaveChanges();
}