using System.Threading.Tasks;
using LibraryControl.Application.Common.Models;

namespace LibraryControl.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password); 
    }
}