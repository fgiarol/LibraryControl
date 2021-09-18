using LibraryControl.Domain.ValueObjects;

namespace LibraryControl.Application.Common.Models
{
    public record UserInputModel(
        string Name,
        Email Email,
        string Password);

    public record AdminUserInputModel(
        string Name,
        Email Email,
        string Password,
        bool Admin);
}