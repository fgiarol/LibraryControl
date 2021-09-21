using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Infrastructure.Persistence.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context) { }
    }
}