using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Enums;
using MediatR;

namespace LibraryControl.Application.Commands.Genres
{
    public static class UpdateGenre
    {
        public record InputModel(string Name);
            
        public record Command(Guid Id, string Name) : IRequest<Guid>;
        
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IGenreRepository _repository;

            public Handler(IGenreRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var genre = await _repository.FindById(request.Id);

                if (genre is null)
                    return Guid.Empty;
                
                genre.Update(request.Name);

                await _repository.Update(genre);

                return genre.Id;
            }
        }
    }
}