using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Enums;
using MediatR;

namespace LibraryControl.Application.Commands.Authors
{
    public static class UpdateAuthor
    {
        public record Command(
            Guid Id,
            string Name,
            ushort? Age,
            EGender? Gender,
            string Description) : IRequest<Guid>;
        
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IAuthorRepository _repository;

            public Handler(IAuthorRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var author = await _repository.FindById(request.Id);

                if (author is null)
                    return Guid.Empty;
                
                author.Update(request.Name, request.Age, request.Gender, request.Description);

                await _repository.Update(author);

                return author.Id;
            }
        }
    }
}