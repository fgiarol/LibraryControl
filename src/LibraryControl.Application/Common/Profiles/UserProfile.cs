using AutoMapper;
using LibraryControl.Application.Queries.Books;
using LibraryControl.Application.Queries.Users;
using LibraryControl.Domain.Entities;

namespace LibraryControl.Application.Common.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetAllUsers.Response>();
            CreateMap<User, GetUserById.Response>();
        }
    }
}