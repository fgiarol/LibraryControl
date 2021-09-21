using LibraryControl.Domain.Entities;

namespace LibraryControl.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}