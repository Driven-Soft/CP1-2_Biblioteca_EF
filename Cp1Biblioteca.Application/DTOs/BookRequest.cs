using System.ComponentModel.DataAnnotations;
using Cp1Biblioteca.Entities;

namespace Cp1Biblioteca.Application.DTOs;

/// <summary>
/// DTO de entrada utilizado para criar um conteúdo.
/// </summary>
public class BookRequest
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "PublicationDate is required")]
    public DateTime PublicationDate { get; set; }

    [Required(ErrorMessage = "PublisherId is required")]
    public int PublisherId { get; set; }

    public Book ToDomain() =>
        new Book(Title, PublicationDate, PublisherId);
}