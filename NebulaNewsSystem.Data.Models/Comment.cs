using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNewsSystem.Data.Models
{
    [NotMapped] 
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }

        [Required]
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        //public int Likes { get; set; }
        //public int Dislikes { get; set; }
        public Guid ArticleId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public virtual Article Article { get; set; } = null!;       
        public Guid? CommenterId { get; set; }        
        public virtual ApplicationUser? Commenter { get; set; }

        //public bool IsAnonymous { get; set; }
        //public string IPAddress { get; set; }
        //public bool IsReported { get; set; }

    }
}
