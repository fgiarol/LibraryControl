using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using MediatR;

namespace LibraryControl.Application.Commands.Authors
{
    public static class DeleteAuthor
    {
        public record Command(Guid Id) : IRequest<Guid>;
        
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IAuthorRepository _repository;

            public Handler(IAuthorRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var author = await _repository.FindByIdAsync(request.Id);

                if (author is null)
                    return Guid.Empty;
                
                await _repository.RemoveAsync(author.Id);
                return author.Id;
            }
        }
    }
}