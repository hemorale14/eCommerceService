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
    public class QueryFilter
    {
        public class AuthorUnic : IRequest<Model.Author>
        {
            public string AuthorGuid { get; set; }
        }

        public class ManageHandler : IRequestHandler<AuthorUnic, Model.Author>
        {
            public readonly AuthorContext _context;

            public ManageHandler(AuthorContext context)
            {
                _context = context;
            }

            public async Task<Model.Author> Handle(AuthorUnic request, CancellationToken cancellationToken)
            {
                var author =  await _context.Author.Where(a => a.AuthorGuid.Equals(request.AuthorGuid)).FirstOrDefaultAsync();
                if (author == null) {
                    throw new Exception("Author is not exist.");
                }
                return author;
            }
        }
    }
}
