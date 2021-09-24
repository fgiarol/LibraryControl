using LibraryControl.Domain.Enums;

namespace LibraryControl.Api.Contracts.Requests
{
    public record AuthorModel(
        string Name,
        ushort? Age,
        EGender? Gender,
        string Description);
}