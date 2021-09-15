using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using LibraryControl.Domain.ValueObjects;
using MediatR;

namespace LibraryControl.Application.Commmands.Users
{
    public static class AddUser
    {
        public record Command(
            string Name,
            Email Email,
            string Password,
            bool Admin) : IRequest<Guid>;
        
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
                    request.Password,
                    request.Admin);

                await _repository.Add(user);

                return user.Id;
            }
        }
    }
}