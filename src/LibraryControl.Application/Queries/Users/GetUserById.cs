using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.Entities;
using LibraryControl.Domain.ValueObjects;
using MediatR;

namespace LibraryControl.Application.Queries.Users
{
    public static class GetUserById
    {
        public record Query(Guid Id) : IRequest<Response>;
        
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly IRepository<User> _repository;
            private readonly IMapper _mapper;

            public Handler(IRepository<User> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _repository.FindByIdAsync(request.Id);
                return _mapper.Map<Response>(user);
            }
        }
        
        public record Response(
            Guid Id, 
            string Name, 
            Email Email,
            bool Admin,
            IEnumerable<Book> CreatedBooks,
            IEnumerable<Reserve> Reserves);
    }
}