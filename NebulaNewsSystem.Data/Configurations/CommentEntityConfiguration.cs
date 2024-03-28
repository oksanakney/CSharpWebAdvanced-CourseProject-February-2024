using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NebulaNewsSystem.Data.Models;

namespace NebulaNewsSystem.Data.Configurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasOne(c => c.Author)
                .WithMany(a => a.CommentsWrittenByAuthor)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
