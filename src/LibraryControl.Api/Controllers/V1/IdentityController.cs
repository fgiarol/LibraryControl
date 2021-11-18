using System.Threading.Tasks;
using LibraryControl.Api.Contracts.V1;
using LibraryControl.Api.Contracts.V1.Requests;
using LibraryControl.Api.Contracts.V1.Responses;
using LibraryControl.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryControl.Api.Controllers.V1
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        
        [HttpPost(ApiRoutes.Identity.Login)]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.Email.Address, request.Password);

            if (!authResponse.Success)
                return BadRequest(new AuthFailedResponse(authResponse.Errors));

            return Ok(new AuthSuccessResponse(authResponse.Token));
        }
    }
}