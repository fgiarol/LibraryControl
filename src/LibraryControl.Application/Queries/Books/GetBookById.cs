using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using MediatR;

namespace LibraryControl.Application.Queries.Books
{
    public static class GetBookById
    {
        public record Query(Guid Id) : IRequest<Response>;
        
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly IBookRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IBookRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var book = await _repository.FindByIdAsync(request.Id);
                return _mapper.Map<Response>(book);
            }
        }
        
        public record Response(
            Guid Id, 
            string Name, 
            uint Quantity,
            string Synopsis,
            IEnumerable<Genre> Genres,
            IEnumerable<Author> Authors,
            IEnumerable<Reserve> Reserves,
            User UserCreation);
    }
}