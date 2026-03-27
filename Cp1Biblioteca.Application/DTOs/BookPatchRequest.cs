using System.ComponentModel.DataAnnotations;

namespace Cp1Biblioteca.Application.DTOs;

/// <summary>
/// DTO de entrada para atualização parcial de um livro.
/// </summary>
public class BookPatchRequest
{
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters")]
    public string? Title { get; set; }

    public DateTime? PublicationDate { get; set; }

    public int? PublisherId { get; set; }
}