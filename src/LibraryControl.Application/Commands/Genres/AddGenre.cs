using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using LibraryControl.Domain.Enums;
using MediatR;

namespace LibraryControl.Application.Commands.Genres
{
    public static class AddGenre
    {
        public record Command(string Name) : IRequest<Guid>;
        
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IGenreRepository _repository;

            public Handler(IGenreRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var genre = new Genre(request.Name);

                await _repository.AddAsync(genre);

                return genre.Id;
            }
        }
    }
}