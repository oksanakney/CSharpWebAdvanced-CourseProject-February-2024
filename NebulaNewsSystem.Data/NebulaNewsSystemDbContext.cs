using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Data.Models;
using System.Reflection;

namespace NebulaNewsSystem.Web.Data
{
    public class NebulaNewsSystemDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public NebulaNewsSystemDbContext(DbContextOptions<NebulaNewsSystemDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(NebulaNewsSystemDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }


    }
}
