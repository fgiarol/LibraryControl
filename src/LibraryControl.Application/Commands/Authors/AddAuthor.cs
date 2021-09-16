using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using LibraryControl.Domain.Enums;
using MediatR;

namespace LibraryControl.Application.Commands.Authors
{
    public static class AddAuthor
    {
        public record Command(
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
                var author = new Author(
                    request.Name,
                    request.Age,
                    request.Gender,
                    request.Description);

                await _repository.Add(author);

                return author.Id;
            }
        }
    }
}