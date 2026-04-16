using Microsoft.EntityFrameworkCore;
using Cp1Biblioteca.Application.Services;
using Cp1Biblioteca.Application.Interfaces.Repositories;
using Cp1Biblioteca.Infrastructure.Persistence;
using Cp1Biblioteca.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<BibliotecaContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("BibliotecaDB");
    options.UseSqlite(connectionString);
});

// Repositórios
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();