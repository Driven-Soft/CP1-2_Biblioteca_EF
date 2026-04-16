namespace Cp1Biblioteca.Infrastructure.Repositories;

using Cp1Biblioteca.Application.Interfaces.Repositories;
using Cp1Biblioteca.Entities;
using Cp1Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class PublisherRepository : IPublisherRepository
{
    private readonly BibliotecaContext _context;
    public PublisherRepository(BibliotecaContext context) => _context = context;

    public IReadOnlyCollection<Publisher> GetAll() =>
        _context.Publishers.Include(p => p.Books).ToList();

    public Publisher? GetById(int id) =>
        _context.Publishers.Include(p => p.Books).FirstOrDefault(p => p.Id == id);

    public void Add(Publisher entity) => _context.Publishers.Add(entity);
    public void Update(Publisher entity) => _context.Publishers.Update(entity);
    public void Delete(Publisher entity) => _context.Publishers.Remove(entity);
    public void SaveChanges() => _context.SaveChanges();
}