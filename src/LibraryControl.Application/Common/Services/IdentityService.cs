using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces;
using LibraryControl.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace LibraryControl.Application.Common.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        public IdentityService(IApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationResult> LoginAsync(string emailAddress, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Email.Address == emailAddress);
            var hash = PasswordHasher.Hash(password);
            var isValid = PasswordHasher.Verify(hash, user.Password);

            if (!isValid)
            {
                //TODO: return a notification

                return new AuthenticationResult
                {
                    Success = false,
                    Errors = new[] {"Invalid username or password"}
                };
            }

            return new AuthenticationResult
            {
                Token = _tokenService.GenerateToken(user),
                Success = true
            };
        }
    }
}