using System;
using System.Threading.Tasks;
using LibraryControl.Api.Contracts.V1;
using LibraryControl.Api.Contracts.V1.Requests;
using LibraryControl.Api.Contracts.V1.Responses;
using LibraryControl.Application.Commands.Users;
using LibraryControl.Application.Common.Interfaces;
using LibraryControl.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryControl.Api.Controllers.V1
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;

        public UsersController(IMediator mediator, IIdentityService identityService)
        {
            _mediator = mediator;
            _identityService = identityService;
        }
        
        [HttpPost(ApiRoutes.Users.Login)]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.Email.Address, request.Password);

            if (!authResponse.Success)
                return BadRequest(new AuthFailedResponse(authResponse.Errors));

            return Ok(new AuthSuccessResponse(authResponse.Token));
        }

        [HttpGet(ApiRoutes.Users.Get)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid userId)
        {
            var query = new GetUserById.Query(userId);
            var result = await _mediator.Send(query);
            
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost(ApiRoutes.Users.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] UserCreationRequest request)
        {
            var command = new AddUser.Command(
                request.Name,
                request.Email,
                request.Password,
                request.Admin);
            
            var result = await _mediator.Send(command);
            return result == Guid.Empty ? Problem(statusCode: StatusCodes.Status400BadRequest) : CreatedAtAction(nameof(GetById), new { id = result }, command);
        }

        [HttpPut(ApiRoutes.Users.Update)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid userId, [FromBody] UserUpdateRequest request)
        {
            var command = new UpdateUser.Command(
                userId,
                request.Name,
                request.Email,
                request.Password);
            
            var result = await _mediator.Send(command);
            return result != Guid.Empty ? NoContent() : NotFound();
        }
        
        [HttpDelete(ApiRoutes.Users.Delete)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var command = new DeleteUser.Command(userId);
            var result = await _mediator.Send(command);
            
            return result != Guid.Empty ? NoContent() : NotFound();
        }
    }
}