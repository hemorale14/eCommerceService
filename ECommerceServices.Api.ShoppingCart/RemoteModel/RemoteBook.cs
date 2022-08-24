using System;

namespace ECommerceServices.Api.ShoppingCart.RemoteModel
{
    public class RemoteBook
    {
        public Guid? BookId { get; set; }
        public string Title { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid? AuthorGuid { get; set; }
    }
}
