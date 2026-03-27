using Microsoft.EntityFrameworkCore;
using Cp1Biblioteca.Application.Services;
using Cp1Biblioteca.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Service (Content → Book + correção de lifetime)
builder.Services.AddScoped<IBookService, BookService>();

// OpenAPI
builder.Services.AddOpenApi();

// DbContext (Recommenda → Biblioteca)
builder.Services.AddDbContext<BibliotecaContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("BibliotecaMySQL");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Pipeline
app.MapControllers();

app.Run();