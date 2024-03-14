using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NebulaNewsSystem.Data.Models;

namespace NebulaNewsSystem.Data.Configurations.SeedCofiguration
{
    public class SeedCommentsEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {            
            builder.HasData(this.GenerateComments());
        }

        private Comment[] GenerateComments()
        {
            ICollection<Comment> comments = new List<Comment>();

            Comment comment;

            comment = new Comment()
            {
                CommentId = Guid.Parse("53e508ee-3a15-4d7a-868a-00c38be79b84"),
                Content = "Dobre e taka, triabva da se vkara malko disciplina v gimnazijata",
                CreationDate = DateTime.UtcNow,
                ArticleId = Guid.Parse("49cde94c-3f90-4f95-8e91-a751aa2b7af4"),
                CommenterId = "247929cd-14da-4c78-bcc7-92fb93e300a1"
            };
            comments.Add(comment);

            comment = new Comment()
            {
                CommentId = Guid.Parse("1ce4973f-a458-4777-ac31-9032bd11f426"),
                Content = "emi za tova se praviat tolkova katastrofi, triabva da se vzemat merki",
                CreationDate = DateTime.UtcNow,
                ArticleId = Guid.Parse("550f78bf-9c45-4fa1-9a1e-4af3a5192be6"),
                CommenterId = "20cd7080-3221-4b5e-96c9-f6ebd93555de"
            };
            comments.Add(comment);

            comment = new Comment()
            {
                CommentId = Guid.Parse("a57e0fc2-96d6-41e8-ac14-aaf5f91872b4"),
                Content = "Bravo na Gi4ka, da gi razkara oti stanali sa mnogo nagli",
                CreationDate = DateTime.UtcNow,
                ArticleId = Guid.Parse("3c74cdaa-71b0-4789-89e0-93c72fd2e8a9"),
                CommenterId = "5c65b87d-ab20-4314-bf26-4c7dbcca0924"
            };
            comments.Add(comment);

            return comments.ToArray();
        }
    }
}
