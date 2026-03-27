using Microsoft.AspNetCore.Mvc;
using Cp1Biblioteca.Application.DTOs;
using Cp1Biblioteca.Application.Services;

namespace Cp1Biblioteca.Api.Controllers
{
    /// <summary>
    /// Controlador responsável pelos endpoints da API de livros.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _bookService.GetAll();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var book = _bookService.GetById(id);

            if (book is null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(BookRequest bookRequest)
        {
            var bookResponse = _bookService.Create(bookRequest);

            return CreatedAtAction(
                nameof(GetById),
                new { id = bookResponse.Id },
                bookResponse
            );
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, BookRequest bookRequest)
        {
            var bookResponse = _bookService.Update(id, bookRequest);

            if (bookResponse is null)
                return NotFound();

            return Ok(bookResponse);
        }

        [HttpPatch("{id:guid}")]
        public IActionResult Patch(Guid id, BookPatchRequest bookPatchRequest)
        {
            var bookResponse = _bookService.Patch(id, bookPatchRequest);

            if (bookResponse is null)
                return NotFound();

            return Ok(bookResponse);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var removed = _bookService.Delete(id);

            if (!removed)
                return NotFound();

            return NoContent();
        }
    }
}