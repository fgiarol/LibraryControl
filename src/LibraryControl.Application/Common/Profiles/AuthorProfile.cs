using AutoMapper;
using LibraryControl.Application.Queries.Authors;
using LibraryControl.Application.Queries.Books;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Application.Common.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, GetAllAuthors.Response>();
            CreateMap<Author, GetAuthorById.Response>();
        }
    }
}