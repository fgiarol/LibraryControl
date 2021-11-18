using System;
using System.Threading.Tasks;
using LibraryControl.Api.Contracts.V1;
using LibraryControl.Api.Contracts.V1.Requests;
using LibraryControl.Application.Commands.Genres;
using LibraryControl.Application.Queries.Genres;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryControl.Api.Controllers.V1
{
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet(ApiRoutes.Genres.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllGenres.Query();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet(ApiRoutes.Genres.Get)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid genreId)
        {
            var query = new GetGenreById.Query(genreId);
            var result = await _mediator.Send(query);
            
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost(ApiRoutes.Genres.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] GenreCreationRequest request)
        {
            var command = new AddGenre.Command(request.Name);
            var result = await _mediator.Send(command);
            
            return result == Guid.Empty ? Problem(statusCode: StatusCodes.Status400BadRequest) : CreatedAtAction(nameof(GetById), new { id = result }, command);
        }

        [HttpPut(ApiRoutes.Genres.Update)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid genreId, [FromBody] GenreUpdateRequest request)
        {
            var command = new UpdateGenre.Command(genreId, request.Name);
            var result = await _mediator.Send(command);
            
            return result != Guid.Empty ? NoContent() : NotFound();
        }

        [HttpDelete(ApiRoutes.Genres.Delete)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid genreId)
        {
            var command = new DeleteGenre.Command(genreId);
            var result = await _mediator.Send(command);
            
            return result != Guid.Empty ? NoContent() : NotFound();
        }
    }
}
