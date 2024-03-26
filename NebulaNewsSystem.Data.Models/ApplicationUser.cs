using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NebulaNewsSystem.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {

        //[Key]
        //public override string Id { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Article> CommentedArticles { get; set; } = new List<Article>();
    }
}
