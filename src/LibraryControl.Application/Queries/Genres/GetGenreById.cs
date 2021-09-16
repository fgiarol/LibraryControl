using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using LibraryControl.Domain.Enums;
using MediatR;

namespace LibraryControl.Application.Queries.Genres
{
    public static class GetGenreById
    {
        public record Query(Guid Id) : IRequest<Response>;
        
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly IGenreRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IGenreRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var genre = await _repository.FindById(request.Id);
                return _mapper.Map<Response>(genre);
            }
        }
        
        public record Response(
            Guid Id, 
            string Name,
            IEnumerable<Book> Books);
    }
}