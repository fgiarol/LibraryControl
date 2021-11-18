using System.Collections.Generic;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Api.Contracts.V1.Requests
{
    public record BookCreationRequest(
        string Name,
        string Synopsis,
        User UserCreation,
        List<Genre> Genres);
    
    public record BookUpdateRequest(
        string Name,
        string Synopsis,
        User UserCreation,
        List<Genre> Genres);
}