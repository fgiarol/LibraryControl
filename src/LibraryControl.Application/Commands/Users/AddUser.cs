using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using LibraryControl.Domain.ValueObjects;
using MediatR;
using SecureIdentity.Password;

namespace LibraryControl.Application.Commands.Users
{
    public static class AddUser
    {
        public record Command(
            string Name,
            Email Email,
            string Password,
            bool Admin = false) : IRequest<Guid>;
        
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IUserRepository _repository;

            public Handler(IUserRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = new User(
                    request.Name,
                    request.Email,
                    PasswordHasher.Hash(request.Password),
                    request.Admin);

                await _repository.AddAsync(user);

                return user.Id;
            }
        }
    }
}