using Microsoft.EntityFrameworkCore;

namespace ECommerceServices.Api.Author.Persistence
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options) { }

        public DbSet<Model.Author> Author { get; set; }
        public DbSet<Model.Degree> Degree { get; set; }
    }
}
