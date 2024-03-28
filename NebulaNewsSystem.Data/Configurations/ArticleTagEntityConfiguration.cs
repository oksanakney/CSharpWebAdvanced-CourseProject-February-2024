using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NebulaNewsSystem.Data.Models;

namespace NebulaNewsSystem.Data.Configurations
{
    public class ArticleTagEntityConfiguration : IEntityTypeConfiguration<ArticleTag>
    {
        public void Configure(EntityTypeBuilder<ArticleTag> builder)
        {
            builder
                .HasKey(at => new { at.ArticleId, at.TagId });

            builder
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticleTags)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
