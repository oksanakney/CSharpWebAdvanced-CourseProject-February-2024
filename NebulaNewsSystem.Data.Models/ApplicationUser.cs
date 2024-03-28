using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace NebulaNewsSystem.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            this.PublishedArticles = new List<Article>();
            this.Comments = new List<Comment>();
        }

        public string CustomTag { get; set; }
        public ICollection<Article> PublishedArticles  { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
    }
}
