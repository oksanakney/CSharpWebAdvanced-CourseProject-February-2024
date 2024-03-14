using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Data.Models;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {          
            builder.Entity<Article>()
                .HasOne(ar => ar.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(ar => ar.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Article>()
                .HasOne(ar => ar.Author)
                .WithMany(au => au.Articles)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(ar => ar.Comments)
                .OnDelete(DeleteBehavior.Restrict);          

            base.OnModelCreating(builder);
        }
    }
}
