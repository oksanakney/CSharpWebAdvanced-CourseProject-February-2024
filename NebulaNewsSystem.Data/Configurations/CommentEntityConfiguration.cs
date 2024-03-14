using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NebulaNewsSystem.Data.Models.Configuration
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
               .HasOne(c => c.Article)
               .WithMany(ar => ar.Comments)
               .OnDelete(DeleteBehavior.Restrict);                     
        }       
    }
}
