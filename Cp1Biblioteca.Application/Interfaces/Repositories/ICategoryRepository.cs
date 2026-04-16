using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Application.Interfaces.Repositories;

public interface ICategoryRepository
{
    IReadOnlyCollection<Category> GetAll();
    Category? GetById(int id);
    void Add(Category entity);
    void Update(Category entity);
    void Delete(Category entity);
    void SaveChanges();
}