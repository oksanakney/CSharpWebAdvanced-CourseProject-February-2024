using Microsoft.AspNetCore.Identity;

namespace NebulaNewsSystem.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            this.CommentedArticles = new HashSet<Article>();
        }
        public virtual ICollection<Article> CommentedArticles { get; set; }
    }
}
