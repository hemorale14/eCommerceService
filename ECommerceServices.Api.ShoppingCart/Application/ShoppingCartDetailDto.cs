using System;

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
