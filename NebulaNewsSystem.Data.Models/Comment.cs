using System.ComponentModel.DataAnnotations;

namespace NebulaNewsSystem.Data.Models
{    
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }

        [Required]
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        //public int Likes { get; set; }
        //public int Dislikes { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        //public bool IsAnonymous { get; set; }
        //public string IPAddress { get; set; }
        //public bool IsReported { get; set; }

    }
}
