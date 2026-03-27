using Cp1Biblioteca.Domain.Commons;

namespace Cp1Biblioteca.Entities;

public class Publisher : BaseEntity
{
    public string Name { get; private set; }
    public List<Book> Books { get; private set; }

    public Publisher(string name)
    {
        Name = name;
    }
}