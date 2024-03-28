using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NebulaNewsSystem.Data.Models;

namespace NebulaNewsSystem.Data.Configurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
              .HasMany(u => u.Comments)
              .WithOne(c => c.Commenter)
              .HasForeignKey(c => c.CommenterId)
              .OnDelete(DeleteBehavior.Restrict);

          

        }
    }
}
