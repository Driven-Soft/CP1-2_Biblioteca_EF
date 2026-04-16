using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Application.Interfaces.Repositories;

public interface IPublisherRepository
{
    IReadOnlyCollection<Publisher> GetAll();
    Publisher? GetById(int id);
    void Add(Publisher entity);
    void Update(Publisher entity);
    void Delete(Publisher entity);
    void SaveChanges();
}