using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Data.Models;
using NebulaNewsSystem.Web.Data.Migrations;
using System.Reflection.Emit;

namespace NebulaNewsSystem.Web.Data
{
    public class NebulaNewsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public NebulaNewsDbContext(DbContextOptions<NebulaNewsDbContext> options)
        : base(options)
        {       
        }

        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<ArticleTag> ArticlesTags { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Article
            builder.Entity<Article>()
               .HasOne(a => a.Author)
               .WithMany(author => author.WrittenArticles)
               .HasForeignKey(a => a.AuthorId);

            builder.Entity<Article>()
                .HasOne(a => a.Category)
                .WithMany(category => category.ArticlesByCategory)
                .HasForeignKey(a => a.CategoryId);

            builder.Entity<Article>()
                .HasMany(a => a.ArticleTags)
                .WithOne(at => at.Article)
                .HasForeignKey(at => at.ArticleId);

            builder.Entity<Article>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.Article)
                .HasForeignKey(c => c.ArticleId);

            //Comment
            builder.Entity<Comment>()
               .HasOne(c => c.User)
               .WithMany() // Assuming IdentityUser does not have a collection of comments
               .HasForeignKey(c => c.UserId)
                .IsRequired();

            builder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId)
                .IsRequired();

            builder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany()
                .HasForeignKey(c => c.AuthorId);

            //ArticleTag
            builder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });

            builder.Entity<ArticleTag>()
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticleTags)
                .HasForeignKey(at => at.ArticleId);

            builder.Entity<ArticleTag>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.ArticleTags)
                .HasForeignKey(at => at.TagId);

            base.OnModelCreating(builder);
        }
    }
}
