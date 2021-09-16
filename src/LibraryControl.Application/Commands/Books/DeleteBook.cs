using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryControl.Application.Common.Interfaces.Repositories;
using MediatR;

namespace LibraryControl.Application.Commands.Books
{
    public static class DeleteBook
    {
        public record Command(Guid Id) : IRequest<Guid>;
        
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
                
                await _repository.Remove(book.Id);
                return book.Id;
            }
        }
    }
}