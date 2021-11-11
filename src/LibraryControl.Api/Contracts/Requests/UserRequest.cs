using LibraryControl.Domain.ValueObjects;

namespace LibraryControl.Api.Contracts.Requests
{
    public record UserModel(
        string Name,
        Email Email,
        string Password,
        bool Admin = false);
}