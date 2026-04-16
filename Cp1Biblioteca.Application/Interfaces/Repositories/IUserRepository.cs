using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Application.Interfaces.Repositories;

public interface IUserRepository
{
    IReadOnlyCollection<User> GetAll();
    User? GetById(int id);
    User? GetByEmail(string email);
    void Add(User entity);
    void Update(User entity);
    void Delete(User entity);
    void SaveChanges();
}