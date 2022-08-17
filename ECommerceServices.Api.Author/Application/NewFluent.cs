using ECommerceServices.Api.Author.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceServices.Api.Author.Application
{
    public class NewFluent
    {
        public class Execute : IRequest 
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? BornDate { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute> 
        {
            public ExecuteValidation() 
            {
                RuleFor(v => v.Name).NotEmpty();
                RuleFor(v => v.LastName).NotEmpty();
            }
        }

        public class ManageHandler : IRequestHandler<Execute>
        {
            public readonly AuthorContext _context;

            public ManageHandler(AuthorContext context) 
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var author = new Model.Author 
                { 
                    Name = request.Name,
                    LastName = request.LastName,
                    BornDate = request.BornDate,
                    AuthorGuid = Guid.NewGuid().ToString()
                };
                _context.Author.Add(author);
                var result = await _context.SaveChangesAsync();
                if (result > 0) { return Unit.Value; }
                throw new Exception("Author is not inserted");
            }
        }
    }
}
