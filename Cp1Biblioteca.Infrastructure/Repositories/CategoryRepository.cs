namespace Cp1Biblioteca.Infrastructure.Repositories;

using Cp1Biblioteca.Application.Interfaces.Repositories;
using Cp1Biblioteca.Entities;
using Cp1Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly BibliotecaContext _context;
    public CategoryRepository(BibliotecaContext context) => _context = context;

    public IReadOnlyCollection<Category> GetAll() =>
        _context.Categories.Include(c => c.Books).ToList();

    public Category? GetById(int id) =>
        _context.Categories.Include(c => c.Books).FirstOrDefault(c => c.Id == id);

    public void Add(Category entity) => _context.Categories.Add(entity);
    public void Update(Category entity) => _context.Categories.Update(entity);
    public void Delete(Category entity) => _context.Categories.Remove(entity);
    public void SaveChanges() => _context.SaveChanges();
}