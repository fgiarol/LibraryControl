using System;
using System.Threading.Tasks;
using LibraryControl.Application.Commands.Authors;
using LibraryControl.Application.Queries.Authors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllAuthors.Query();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetAuthorById.Query(id);
            var result = await _mediator.Send(query);
            
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddAuthor.Command command)
        {
            var result = await _mediator.Send(command);
            return result == Guid.Empty ? Problem(statusCode: StatusCodes.Status400BadRequest) : CreatedAtAction(nameof(GetById), new { id = result }, command);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateAuthor.InputModel model)
        {
            var command = new UpdateAuthor.Command(
                id,
                model.Name,
                model.Age,
                model.Gender,
                model.Description);
            
            var result = await _mediator.Send(command);
            return result != Guid.Empty ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAuthor.Command(id);
            var result = await _mediator.Send(command);
            
            return result != Guid.Empty ? NoContent() : NotFound();
        }
    }
}
