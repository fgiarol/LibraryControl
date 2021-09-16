using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Enums;
using MediatR;

namespace LibraryControl.Application.Queries.Genres
{
    public static class GetAllGenres
    {
        public record Query : IRequest<List<Response>>;
        
        public class Handler : IRequestHandler<Query, List<Response>>
        {
            private readonly IGenreRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IGenreRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            
            public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                var genres = await _repository.FindAll();
                return _mapper.Map<List<Response>>(genres);
            }
        }

        public record Response(
            Guid Id, 
            string Name);
    }
}