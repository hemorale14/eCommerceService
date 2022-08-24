using AutoMapper;
using ECommerceServices.Api.Author.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceServices.Api.Author.Application
{
    public class QueryMapper
    {
        public class AuthorList : IRequest<List<AuthorDto>>
        {
        }

        public class ManageHandler : IRequestHandler<AuthorList, List<AuthorDto>>
        {
            public readonly AuthorContext _context;
            public readonly IMapper _mapper;

            public ManageHandler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _context.Author.ToListAsync();
                var authorDto = _mapper.Map<List<Model.Author>, List<AuthorDto>>(authors);
                return authorDto;
            }
        }
    }
}
