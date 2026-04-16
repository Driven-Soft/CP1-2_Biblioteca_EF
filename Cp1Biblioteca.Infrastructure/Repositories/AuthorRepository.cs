namespace Cp1Biblioteca.Infrastructure.Repositories;

using Cp1Biblioteca.Application.Interfaces.Repositories;
using Cp1Biblioteca.Entities;
using Cp1Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class AuthorRepository : IAuthorRepository
{
    private readonly BibliotecaContext _context;
    public AuthorRepository(BibliotecaContext context) => _context = context;

    public IReadOnlyCollection<Author> GetAll() =>
        _context.Authors.Include(a => a.Books).ToList();

    public Author? GetById(int id) =>
        _context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);

    public void Add(Author entity) => _context.Authors.Add(entity);
    public void Update(Author entity) => _context.Authors.Update(entity);
    public void Delete(Author entity) => _context.Authors.Remove(entity);
    public void SaveChanges() => _context.SaveChanges();
}