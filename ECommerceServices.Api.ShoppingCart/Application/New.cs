using ECommerceServices.Api.ShoppingCart.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceServices.Api.ShoppingCart.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime CreateDate { get; set; }

            public List<string> Product { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(v => v.CreateDate).NotEmpty();
                RuleFor(v => v.Product).NotEmpty();
            }
        }

        public class ManageHandler : IRequestHandler<Execute>
        {
            public readonly SessionContext _context;

            public ManageHandler(SessionContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var header = new Model.SessionHeader
                {
                    CreateDate = request.CreateDate
                };
                _context.SessionHeader.Add(header);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    throw new Exception("Session header is not inserted");
                }
                int headerId = header.SessionHeaderId;
                foreach (var item in request.Product)
                {
                    var detail = new Model.SessionDetail
                    {
                        CreateDate = DateTime.Now,
                        SessionHeaderId = headerId,
                        ProductSelected = item
                    };
                    _context.SessionDetail.Add(detail);
                }
                result = await _context.SaveChangesAsync();
                if (result > 0) { return Unit.Value; }
                throw new Exception("Session detail is not inserted");
            }
        }
    }
}
