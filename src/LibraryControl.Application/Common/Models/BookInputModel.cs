using System.Collections.Generic;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Application.Common.Models
{
    public record BookInputModel(
        string Name,
        string Synopsis,
        User UserCreation,
        List<Genre> Genres);
}