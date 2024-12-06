using Application.Books.Commands.CreateBook;
using Application.Books.Commands.DeleteBook;
using Application.Books.Commands.UpdateBook;
using Application.Books.Queries.GetAllBooks;
using Application.Books.Queries.GetBook;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());
            if (books == null || !books.Any())
            {
                return NotFound("No books was found");
            }
            return Ok(books);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int bookId)
        {
            var book = await _mediator.Send(new GetBookQuery(bookId));
            if (book == null)
            {
                return NotFound($"Book with ID {bookId} was not found");
            }
            return Ok($"Book: {book.Id}, Title: {book.Title}, Genre: {book.Genre}");
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] string title, string genre)
        {
            return Ok(await _mediator.Send(new CreateBookCommand(title, genre)));
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(string title,string genre, int id)
        {
            return Ok(await _mediator.Send(new UpdateBookCommand(title, genre, id)));
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            return Ok(await _mediator.Send(new DeleteBookCommand(bookId)));
        }
    }
}
