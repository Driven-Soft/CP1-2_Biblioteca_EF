using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Application.Interfaces.Repositories;

public interface IAuthorRepository
{
    IReadOnlyCollection<Author> GetAll();
    Author? GetById(int id);
    void Add(Author entity);
    void Update(Author entity);
    void Delete(Author entity);
    void SaveChanges();
}

