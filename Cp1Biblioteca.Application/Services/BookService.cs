using Cp1Biblioteca.Application.DTOs;
using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Application.Services;

/// <summary>
/// Serviço responsável pelas operações de livros em memória.
/// </summary>
public class BookService : IBookService
{
    private readonly List<Book> _books = [];

    public IReadOnlyCollection<BookResponse> GetAll()
    {
        return _books
            .Select(book => new BookResponse(book))
            .ToList();
    }

    public BookResponse? GetById(Guid id)
    {
        var book = _books.FirstOrDefault(item => item.Id.Equals(id));

        return book is null ? null : new BookResponse(book);
    }

    public BookResponse Create(BookRequest bookRequest)
    {
        var book = bookRequest.ToDomain();

        _books.Add(book);

        return new BookResponse(book);
    }

    public BookResponse? Update(Guid id, BookRequest bookRequest)
    {
        var book = _books.FirstOrDefault(item => item.Id.Equals(id));

        if (book is null)
            return null;

        book.Update(
            bookRequest.Title,
            bookRequest.PublicationDate,
            bookRequest.PublisherId
        );

        return new BookResponse(book);
    }

    public BookResponse? Patch(Guid id, BookPatchRequest bookPatchRequest)
    {
        var book = _books.FirstOrDefault(item => item.Id.Equals(id));

        if (book is null)
            return null;

        if (!string.IsNullOrWhiteSpace(bookPatchRequest.Title))
            book.UpdateTitle(bookPatchRequest.Title);

        if (bookPatchRequest.PublicationDate.HasValue)
            book.UpdatePublicationDate(bookPatchRequest.PublicationDate.Value);

        if (bookPatchRequest.PublisherId.HasValue)
            book.UpdatePublisher(bookPatchRequest.PublisherId.Value);

        return new BookResponse(book);
    }

    public bool Delete(Guid id)
    {
        var book = _books.FirstOrDefault(item => item.Id.Equals(id));

        if (book is null)
            return false;

        _books.Remove(book);
        return true;
    }
}