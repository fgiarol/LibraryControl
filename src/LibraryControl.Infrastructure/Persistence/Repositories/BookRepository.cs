using System;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Infrastructure.Persistence.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }

        public Task<Book> GetBookWithAuthors(Guid bookId)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAllBooksWithAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAllBooksByAuthor(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByAuthor(Guid bookId, Guid authorId)
        {
            throw new NotImplementedException();
        }
    }
}