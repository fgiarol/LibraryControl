using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}