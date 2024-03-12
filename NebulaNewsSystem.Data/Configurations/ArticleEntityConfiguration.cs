using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NebulaNewsSystem.Data.Models;

namespace NebulaNewsSystem.Data.Configurations
{
    public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasOne(ar => ar.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(ar => ar.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ar => ar.Author)
                .WithMany(au => au.Articles)
                .HasForeignKey(ar => ar.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
