using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces;
using LibraryControl.Application.Common.Models;

namespace LibraryControl.Application.Common.Services
{
    public class IdentityService : IIdentityService
    {
        public Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}