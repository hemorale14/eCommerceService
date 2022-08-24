using AutoMapper;
using ECommerceServices.Api.Author.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceServices.Api.Author.Application
{
    public class QueryFilterMapper
    {
        public class AuthorUnic : IRequest<AuthorDto>
        {
            public string AuthorGuid { get; set; }
        }

        public class ManageHandler : IRequestHandler<AuthorUnic, AuthorDto>
        {
            public readonly AuthorContext _context;
            public readonly IMapper _mapper;

            public ManageHandler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorDto> Handle(AuthorUnic request, CancellationToken cancellationToken)
            {
                var author = await _context.Author.Where(a => a.AuthorGuid.Equals(request.AuthorGuid)).FirstOrDefaultAsync();
                var authorDto = _mapper.Map<Model.Author, AuthorDto>(author);
                if (authorDto == null)
                {
                    throw new Exception("Author is not exist.");
                }
                return authorDto;
            }
        }
    }
}
