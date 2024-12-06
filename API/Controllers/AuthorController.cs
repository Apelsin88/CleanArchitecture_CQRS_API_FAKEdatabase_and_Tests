using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Commands.DeleteAuthor;
using Application.Authors.Commands.UpdateAuthor;
using Application.Authors.Queries.GetAllAuthors;
using Application.Authors.Queries.GetAuthor;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            if (authors == null || !authors.Any())
            {
                return NotFound("No authors was found");
            }
            return Ok(authors);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int authorId)
        {
            var author = await _mediator.Send(new GetAuthorQuery(authorId));
            if (author == null)
            {
                return NotFound($"Author with ID {authorId} was not found");
            }
            return Ok($"Author: {author.Id}, Name: {author.Name}");
        }


        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] string name)
        {
            return Ok(await _mediator.Send(new CreateAuthorCommand(name)));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(string name, int id)
        {
            return Ok(await _mediator.Send(new UpdateAuthorCommand(name, id)));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            return Ok(await _mediator.Send(new DeleteAuthorCommand(authorId)));
        }
    }
}
