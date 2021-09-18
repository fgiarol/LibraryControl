using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using MediatR;

namespace LibraryControl.Application.Commands.Books
{
    public static class UpdateBook
    {
        public record Command(
            Guid Id,
            string Name,
            string Synopsis,
            User UserCreation,
            List<Genre> Genres) : IRequest<Guid>;
        
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IBookRepository _repository;

            public Handler(IBookRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var book = await _repository.FindById(request.Id);

                if (book is null)
                    return Guid.Empty;
                
                book.Update(request.Name, request.Synopsis);
                
                //TODO: Validar se os generos ja estao inclusos no livro
                
                book.LinkGenres(request.Genres);
                
                await _repository.Update(book);

                return book.Id;
            }
        }
    }
}