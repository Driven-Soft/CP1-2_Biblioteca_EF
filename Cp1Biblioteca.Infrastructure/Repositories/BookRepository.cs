namespace Cp1Biblioteca.Infrastructure.Repositories;

using Cp1Biblioteca.Application.Interfaces.Repositories;
using Cp1Biblioteca.Entities;
using Cp1Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly BibliotecaContext _context;
    public BookRepository(BibliotecaContext context) => _context = context;

    public IReadOnlyCollection<Book> GetAll() =>
        _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Categories)
            .Include(b => b.Publisher)
            .ToList();

    public Book? GetById(int id) =>
        _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Categories)
            .Include(b => b.Publisher)
            .FirstOrDefault(b => b.Id == id);

    public void Add(Book entity) => _context.Books.Add(entity);
    public void Update(Book entity) => _context.Books.Update(entity);
    public void Delete(Book entity) => _context.Books.Remove(entity);
    public void SaveChanges() => _context.SaveChanges();
}