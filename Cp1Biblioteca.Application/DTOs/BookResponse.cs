using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Application.DTOs;

public class BookResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public int PublisherId { get; set; }

    public BookResponse(Book book)
    {
        Id = book.Id;
        Title = book.Title;
        PublicationDate = book.PublicationDate;
        PublisherId = book.PublisherId;
    }
}