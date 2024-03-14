using Microsoft.EntityFrameworkCore;

namespace NebulaNewsSystem.Data.Models.Configuration
{
    public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Article> builder)
        {
            builder
               .HasOne(ar => ar.Category)
               .WithMany(c => c.Articles)
               .HasForeignKey(ar => ar.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ar => ar.Author)
                .WithMany(au => au.Articles)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);            
        }       
        
    }
}
