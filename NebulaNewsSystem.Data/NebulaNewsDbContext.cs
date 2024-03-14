using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Data.Models;
using System.Reflection;
using System.Reflection.Emit;


namespace NebulaNewsSystem.Web.Data
{
    public class NebulaNewsDbContext : IdentityDbContext
    {
        public NebulaNewsDbContext(DbContextOptions<NebulaNewsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;


        // TODO: TRY TO REMOVE THIS TO Article, cooment Enity Config
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(NebulaNewsDbContext)) ?? 
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);                     

            base.OnModelCreating(builder);
        }
    }
}
