using ECommerceServices.Api.ShoppingCart.Persistence;
using ECommerceServices.Api.ShoppingCart.RemoteInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceServices.Api.ShoppingCart.Application
{
    public class Query
    {
        public class Execute : IRequest<ShoppingCartDto>
        {
            public int HeaderId { get; set; }
        }

        public class ManageHandler : IRequestHandler<Execute, ShoppingCartDto>
        {
            public readonly SessionContext _context;
            public readonly IBookService _bookService;

            public ManageHandler(SessionContext context, IBookService bookService) {
                _context = context;
                _bookService = bookService;
            }
            public async Task<ShoppingCartDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var sessionHeader = await _context.SessionHeader.FirstOrDefaultAsync(s => s.SessionHeaderId == request.HeaderId);
                var sessionDetail = await _context.SessionDetail.Where(s => s.SessionHeaderId == request.HeaderId).ToListAsync();
                var dtos = new List<ShoppingCartDetailDto>();
                foreach(var book in sessionDetail){
                    var response = await _bookService.GetBook(new Guid(book.ProductSelected));
                    if (response.result) {
                        var objBook = response.Book;
                        var ShoppingCartDetailDto = new ShoppingCartDetailDto {
                            Title = objBook.Title,
                            PublishDate = objBook.PublishDate,
                            BookId = objBook.BookId
                        };
                        dtos.Add(ShoppingCartDetailDto);
                    }
                }

                var sessionDto = new ShoppingCartDto
                {
                    HeaderId = sessionHeader.SessionHeaderId,
                    CreateDate = sessionHeader.CreateDate,
                    Products = dtos
                };
                return sessionDto;
            }
        }
    }
}
