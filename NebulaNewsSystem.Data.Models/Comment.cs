﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid ArticleId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public virtual Article Article { get; set; } = null!;

        [Required]
        public string? CommenterId { get; set; }

        [ForeignKey(nameof(CommenterId))]
        public virtual IdentityUser? Commenter { get; set; }

        //public bool IsAnonymous { get; set; }
        //public string IPAddress { get; set; }
        //public bool IsReported { get; set; }

    }
}
