using System;
using System.Threading.Tasks;
using LibraryControl.Api.Contracts.V1;
using LibraryControl.Api.Contracts.V1.Requests;
using LibraryControl.Application.Commands.Authors;
using LibraryControl.Application.Queries.Authors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryControl.Api.Controllers.V1
{
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet(ApiRoutes.Authors.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllAuthors.Query();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet(ApiRoutes.Authors.Get)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid authorId)
        {
            var query = new GetAuthorById.Query(authorId);
            var result = await _mediator.Send(query);
            
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost(ApiRoutes.Authors.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AuthorCreationRequest request)
        {
            var command = new AddAuthor.Command(
                request.Name,
                request.Age,
                request.Gender,
                request.Description);
            
            var result = await _mediator.Send(command);
            return result == Guid.Empty ? Problem(statusCode: StatusCodes.Status400BadRequest) : CreatedAtAction(nameof(GetById), new { id = result }, command);
        }

        [HttpPut(ApiRoutes.Authors.Update)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid authorId, [FromBody] AuthorUpdateRequest request)
        {
            var command = new UpdateAuthor.Command(
                authorId,
                request.Name,
                request.Age,
                request.Gender,
                request.Description);
            
            var result = await _mediator.Send(command);
            return result != Guid.Empty ? NoContent() : NotFound();
        }

        [HttpDelete(ApiRoutes.Authors.Delete)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid authorId)
        {
            var command = new DeleteAuthor.Command(authorId);
            var result = await _mediator.Send(command);
            
            return result != Guid.Empty ? NoContent() : NotFound();
        }
    }
}
