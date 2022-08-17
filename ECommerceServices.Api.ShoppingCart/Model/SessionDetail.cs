using System;

namespace ECommerceServices.Api.ShoppingCart.Model
{
    public class SessionDetail
    {
        public int SessionDetailId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ProductSelected { get; set; }
        public int SessionHeaderId { get; set; }
        public int SessionHeader { get; set; }
    }
}
