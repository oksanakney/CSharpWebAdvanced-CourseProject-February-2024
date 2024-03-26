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

            // Configure the relationship between Comment and AspNetUsers
            builder
                .HasOne(c => c.Commenter)           // Comment has one Commenter
                .WithMany(u => u.Comments)           // Commenter can have many Comments
                .HasForeignKey(c => c.UserId)  // Foreign key property in Comment entity
                .IsRequired(false)                  // Depending on your requirements
                .OnDelete(DeleteBehavior.Restrict)  // Specify delete behavior if needed
                .HasConstraintName("FK_Comment_AspNetUsers_CommenterId"); // Specify the constraint name
        }       
    }
}
