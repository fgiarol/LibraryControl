using AutoMapper;
using LibraryControl.Application.Queries.Genres;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Application.Common.Profiles
{
    public class GenreProfile: Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GetAllGenres.Response>();
            CreateMap<Genre, GetGenreById.Response>();
        }
    }
}