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
    public static class GetAllAuthors
    {
        public record Query : IRequest<List<Response>>;
        
        public class Handler : IRequestHandler<Query, List<Response>>
        {
            private readonly IAuthorRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IAuthorRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            
            public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                var authors = await _repository.FindAll();
                return _mapper.Map<List<Response>>(authors);
            }
        }

        public record Response(
            Guid Id, 
            string Name, 
            ushort? Age,
            EGender? Gender);
    }
}