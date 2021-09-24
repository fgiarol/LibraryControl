using System.Collections.Generic;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Api.Contracts.Requests
{
    public record BookModel(
        string Name,
        string Synopsis,
        User UserCreation,
        List<Genre> Genres);
}