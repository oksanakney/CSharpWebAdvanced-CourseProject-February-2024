using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Data.Models;


namespace NebulaNewsSystem.Web.Data
{
    public class NebulaNewsSystemDbContext : IdentityDbContext
    {
        public NebulaNewsSystemDbContext(DbContextOptions<NebulaNewsSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}
