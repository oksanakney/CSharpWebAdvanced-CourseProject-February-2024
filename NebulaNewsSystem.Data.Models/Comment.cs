using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NebulaNewsSystem.Common.EntityValidationConstants.Comment;

namespace NebulaNewsSystem.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }

        public Guid CommenterId { get; set; }        

        [ForeignKey(nameof(CommenterId))]
        public ApplicationUser Commenter { get; set; } = null!;

        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = null!;

        public Guid ArticleId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public Article Article { get; set; } = null!;      
    }
}
