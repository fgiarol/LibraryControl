using LibraryControl.Domain.Enums;

namespace LibraryControl.Application.Common.Models
{
    public record AuthorInputModel(
        string Name,
        ushort? Age,
        EGender? Gender,
        string Description);
}