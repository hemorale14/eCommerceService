using ECommerceServices.Api.Author.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceServices.Api.Author.Application
{
    public class Query
    {
        public class AuthorList : IRequest<List<Model.Author>> { 
        }

        public class ManageHandler : IRequestHandler<AuthorList, List<Model.Author>>
        {
            public readonly AuthorContext _context;

            public ManageHandler(AuthorContext context) 
            {
                _context = context;
            }

            public async Task<List<Model.Author>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _context.Author.ToListAsync();
                return authors;
            }
        }
    }
}
