using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using LibraryControl.Domain.Enums;
using MediatR;

namespace LibraryControl.Application.Queries.Authors
{
    public static class GetAuthorById
    {
        public record Query(Guid Id) : IRequest<Response>;
        
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly IAuthorRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IAuthorRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var author = await _repository.FindById(request.Id);
                return _mapper.Map<Response>(author);
            }
        }
        
        public record Response(
            Guid Id, 
            string Name, 
            ushort? Age,
            EGender? Gender,
            IEnumerable<Book> Books);
    }
}