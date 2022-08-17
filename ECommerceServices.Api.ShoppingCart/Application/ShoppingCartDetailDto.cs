using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceServices.Api.ShoppingCart.Application
{
    public class ShoppingCartDetailDto
    {
        public Guid? BookId { get; set; }
        public string Title { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid? AuthorName { get; set; }

    }
}
