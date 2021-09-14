using System;
using System.Threading.Tasks;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Application.Common.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookWithAuthors(Guid bookId);
        Task<Book> GetAllBooksWithAuthors();
        Task<Book> GetAllBooksByAuthor(Guid authorId);
        Task<Book> GetBookByAuthor(Guid bookId, Guid authorId);
    }
}