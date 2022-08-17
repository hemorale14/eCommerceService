using AutoMapper;
using ECommerceServices.Api.Book.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceServices.Api.Book.Application
{
    public class Query
    {
        public class BookList : IRequest<List<BookDto>>
        {
        }

        public class ManageHandler : IRequestHandler<BookList, List<BookDto>>
        {
            public readonly BookContext _context;
            public readonly IMapper _mapper;

            public ManageHandler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BookDto>> Handle(BookList request, CancellationToken cancellationToken)
            {
                var books = await _context.Book.ToListAsync();
                var bookDtos = _mapper.Map<List<Model.Book>, List<BookDto>>(books);
                return bookDtos;
            }
        }
    }
}
