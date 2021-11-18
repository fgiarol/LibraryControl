using System.Collections.Generic;

namespace LibraryControl.Api.Contracts.V1.Responses
{
    public record AuthFailedResponse(IList<string> Errors);
    public record AuthSuccessResponse(string Token);
}