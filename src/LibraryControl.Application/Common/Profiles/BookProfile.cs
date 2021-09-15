using AutoMapper;
using LibraryControl.Application.Queries.Books;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Application.Common.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, GetAllBooks.Response>();
            CreateMap<Book, GetBookById.Response>();
        }
    }
}