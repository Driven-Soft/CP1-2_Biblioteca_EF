using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Application.Interfaces.Repositories;

public interface IBookRepository
{
    IReadOnlyCollection<Book> GetAll();
    Book? GetById(int id);
    void Add(Book entity);
    void Update(Book entity);
    void Delete(Book entity);
    void SaveChanges();
}