using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NebulaNewsSystem.Web.ViewModels.Comment
{
    public class CommentViewModel
    {
        public string CommentId { get; set; } = null!;        
        public string Content { get; set; } = null!;
        public string CreationDate { get; set; } = null!;
        public string ArticleId { get; set; } = null!;        
        public string? CommenterId { get; set; }        
    }
}
