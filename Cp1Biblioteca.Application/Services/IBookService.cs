using Cp1Biblioteca.Application.DTOs;

namespace Cp1Biblioteca.Application.Services;

/// <summary>
/// Contrato do serviço responsável pelas operações de livros.
/// </summary>
public interface IBookService
{
    IReadOnlyCollection<BookResponse> GetAll();

    BookResponse? GetById(Guid id);

    BookResponse Create(BookRequest bookRequest);

    BookResponse? Update(Guid id, BookRequest bookRequest);

    BookResponse? Patch(Guid id, BookPatchRequest bookPatchRequest);

    bool Delete(Guid id);
}