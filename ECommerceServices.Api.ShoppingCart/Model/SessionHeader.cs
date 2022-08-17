using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceServices.Api.ShoppingCart.Model
{
    public class SessionHeader
    {
        public int SessionHeaderId { get; set; }
        public DateTime? CreateDate { get; set; }

        public ICollection<SessionDetail> SessionDetails { get; set; }
    }
}
