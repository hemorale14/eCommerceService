using Microsoft.EntityFrameworkCore;

namespace ECommerceServices.Api.ShoppingCart.Persistence
{
    public class SessionContext : DbContext
    {
        public SessionContext(DbContextOptions<SessionContext> options) : base(options) { }

        public DbSet<Model.SessionHeader> SessionHeader { get; set; }
        public DbSet<Model.SessionDetail> SessionDetail { get; set; }
    }
}
