using Cp1Biblioteca.Domain.Commons;

namespace Cp1Biblioteca.Entities;

public class Author : BaseEntity
{
    public string Name { get; private set; }
    public List<Book> Books { get; private set; }

    public Author(string name)
    {
        Name = name;
    }
}