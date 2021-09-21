using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context) { }
    }
}