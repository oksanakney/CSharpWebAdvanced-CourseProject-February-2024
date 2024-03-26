using System.ComponentModel.DataAnnotations;
using static NebulaNewsSystem.Common.EntityValidationConstants.Tag;

namespace NebulaNewsSystem.Data.Models
{
    public class Tag
    {
        public Tag()
        {
            this.ArticleTags = new List<ArticleTag>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
        
        public ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
