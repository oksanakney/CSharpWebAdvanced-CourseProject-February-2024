using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NebulaNewsSystem.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            this.CommentedArticles = new HashSet<Article>();
        }

        [Key]
        public string? ApplicationUserId { get; set; }
        public virtual ICollection<Article> CommentedArticles { get; set; }
    }
}
