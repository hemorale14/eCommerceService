using ECommerceServices.Api.Book.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceServices.Api.Book.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime? PublishDate { get; set; }
            public Guid? AuthorGuid { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(v => v.Title).NotEmpty();
                RuleFor(v => v.PublishDate).NotEmpty();
                RuleFor(v => v.AuthorGuid).NotEmpty();
            }
        }

        public class ManageHandler : IRequestHandler<Execute>
        {
            public readonly BookContext _context;

            public ManageHandler(BookContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new Model.Book
                {
                    Title = request.Title,
                    PublishDate = request.PublishDate,
                    AuthorGuid = request.AuthorGuid,
                };
                _context.Book.Add(book);
                var result = await _context.SaveChangesAsync();
                if (result > 0) { return Unit.Value; }
                throw new Exception("Book is not inserted");
            }
        }
    }
}
