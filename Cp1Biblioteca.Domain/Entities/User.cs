using Cp1Biblioteca.Domain.Commons;

namespace Cp1Biblioteca.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string ? TelNumber { get; private set; }

    public List<Loan>? Loans { get; private set; }
    public bool Active { get; private set; }

    public User(string name, string email, string ? telNumber = null, bool active = true)
    {
        Name = name;
        Email = email;
        TelNumber = telNumber;
        Active = active;
    }

    public void Deactivate()
    {
        Active = false;
    }
}