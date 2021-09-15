using LibraryControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryControl.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Reserve> Reserves { get; set; }
        DbSet<User> Users { get; set; }
    }
}