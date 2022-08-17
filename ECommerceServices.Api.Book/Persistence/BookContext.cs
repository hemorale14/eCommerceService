using Microsoft.EntityFrameworkCore;

namespace ECommerceServices.Api.Book.Persistence
{
    public class BookContext : DbContext
    {
        public BookContext() { }
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public virtual DbSet<Model.Book> Book { get; set; }
    }
}
