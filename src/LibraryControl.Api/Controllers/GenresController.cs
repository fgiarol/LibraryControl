using System;
using System.Threading.Tasks;
using LibraryControl.Application.Commands.Genres;
using LibraryControl.Application.Common.Models;
using LibraryControl.Application.Queries.Genres;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllGenres.Query();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetGenreById.Query(id);
            var result = await _mediator.Send(query);
            
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] GenreInputModel model)
        {
            var command = new AddGenre.Command(model.Name);
            var result = await _mediator.Send(command);
            
            return result == Guid.Empty ? Problem(statusCode: StatusCodes.Status400BadRequest) : CreatedAtAction(nameof(GetById), new { id = result }, command);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] GenreInputModel model)
        {
            var command = new UpdateGenre.Command(id, model.Name);
            var result = await _mediator.Send(command);
            
            return result != Guid.Empty ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteGenre.Command(id);
            var result = await _mediator.Send(command);
            
            return result != Guid.Empty ? NoContent() : NotFound();
        }
    }
}
