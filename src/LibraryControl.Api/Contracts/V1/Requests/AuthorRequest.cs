using LibraryControl.Domain.Enums;

namespace LibraryControl.Api.Contracts.V1.Requests
{
    public record AuthorCreationRequest(
        string Name,
        ushort? Age,
        EGender? Gender,
        string Description);
    
    public record AuthorUpdateRequest(
        string Name,
        ushort? Age,
        EGender? Gender,
        string Description);
}