using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryControl.Application.Common.Interfaces.Repositories;
using LibraryControl.Domain.ValueObjects;
using MediatR;

namespace LibraryControl.Application.Queries.Users
{
    public static class GetAllUsers
    {
        public record Query : IRequest<List<Response>>;
        
        public class Handler : IRequestHandler<Query, List<Response>>
        {
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IUserRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            
            public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _repository.FindAllAsync();
                return _mapper.Map<List<Response>>(users);
            }
        }

        public record Response(
            Guid Id, 
            string Name, 
            Email Email,
            bool Admin);
    }
}