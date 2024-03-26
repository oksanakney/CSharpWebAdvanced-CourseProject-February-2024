using System.ComponentModel.DataAnnotations;
using static NebulaNewsSystem.Common.EntityValidationConstants.Category;

namespace NebulaNewsSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.ArticlesByCategory = new List<Article>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }= string.Empty;

        public ICollection<Article> ArticlesByCategory { get; set; } = null!;
    }
}
