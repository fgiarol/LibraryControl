using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using MediatR;

namespace LibraryControl.Application.Commands.Genres
{
    public static class DeleteGenre
    {
        public record Command(Guid Id) : IRequest<Guid>;
        
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IGenreRepository _repository;

            public Handler(IGenreRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var genre = await _repository.FindByIdAsync(request.Id);

                if (genre is null)
                    return Guid.Empty;
                
                await _repository.RemoveAsync(genre.Id);
                return genre.Id;
            }
        }
    }
}