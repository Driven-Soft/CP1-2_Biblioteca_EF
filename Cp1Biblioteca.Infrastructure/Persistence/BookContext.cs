using Microsoft.EntityFrameworkCore;
using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Infrastructure.Persistence;

public class BibliotecaContext : DbContext
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<Loan> Loans { get; set; }
}