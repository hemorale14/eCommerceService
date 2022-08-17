using System;
using System.Collections.Generic;

namespace ECommerceServices.Api.ShoppingCart.Application
{
    public class ShoppingCartDto
    {
        public int HeaderId { get; set; }
        public DateTime? CreateDate { get; set; }

        public List<ShoppingCartDetailDto> Products { get; set; }
    }
}
