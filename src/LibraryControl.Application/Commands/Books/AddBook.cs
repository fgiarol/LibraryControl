using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using MediatR;

namespace LibraryControl.Application.Commands.Books
{
    public static class AddBook
    {
        public record Command(
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
                var book = new Book(
                    request.Name,
                    request.UserCreation,
                    request.Synopsis);
                
                book.LinkGenres(request.Genres);

                await _repository.AddAsync(book);

                return book.Id;
            }
        }
    }
}