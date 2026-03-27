using Cp1Biblioteca.Domain.Commons;

namespace Cp1Biblioteca.Entities;

public class Category : BaseEntity
{
    public String Name { get; private set; }
    public String Description { get; private set; }
    public List<Book> Books { get; private set; }

    public Category(String name, String description)
    {
        Name = name;
        Description = description;
    }
}