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
    public static class GetAllBooks
    {
        public record Query : IRequest<List<Response>>;
        
        public class Handler : IRequestHandler<Query, List<Response>>
        {
            private readonly IBookRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IBookRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            
            public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                var books = await _repository.FindAll();
                return _mapper.Map<List<Response>>(books);
            }
        }

        public record Response(
            Guid Id, 
            string Name, 
            uint Quantity,
            string Synopsis,
            IEnumerable<Genre> Genres,
            IEnumerable<Author> Authors);
    }
}