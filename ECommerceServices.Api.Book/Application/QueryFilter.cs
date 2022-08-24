using AutoMapper;
using ECommerceServices.Api.Book.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceServices.Api.Book.Application
{
    public class QueryFilter
    {
        public class BookUnic : IRequest<BookDto>
        {
            public Guid? BookId { get; set; }
        }

        public class ManageHandler : IRequestHandler<BookUnic, BookDto>
        {
            public readonly BookContext _context;
            public readonly IMapper _mapper;

            public ManageHandler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDto> Handle(BookUnic request, CancellationToken cancellationToken)
            {
                var book = await _context.Book.Where(a => a.BookId == request.BookId).FirstOrDefaultAsync();
                var bookrDto = _mapper.Map<Model.Book, BookDto>(book);
                if (bookrDto == null)
                {
                    throw new Exception("Book is not exist.");
                }
                return bookrDto;
            }
        }
    }
}
