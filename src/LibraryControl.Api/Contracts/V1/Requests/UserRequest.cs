using LibraryControl.Domain.ValueObjects;

namespace LibraryControl.Api.Contracts.V1.Requests
{
    public record UserCreationRequest(
        string Name,
        Email Email,
        string Password,
        bool Admin = false);
    
    public record UserUpdateRequest(
        string Name,
        Email Email,
        string Password,
        bool Admin = false);
    
    public record UserAuthenticationRequest(
        string Name,
        Email Email,
        string Password);
}