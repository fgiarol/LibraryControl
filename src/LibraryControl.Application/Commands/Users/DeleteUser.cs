using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using MediatR;

namespace LibraryControl.Application.Commands.Users
{
    public static class DeleteUser
    {
        public record Command(Guid Id) : IRequest<Guid>;
        
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IUserRepository _repository;

            public Handler(IUserRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _repository.FindById(request.Id);

                if (user is null)
                    return Guid.Empty;
                
                await _repository.Remove(request.Id);
                return request.Id;
            }
        }
    }
}