using System.ComponentModel.DataAnnotations;
using static NebulaNewsSystem.Common.EntityValidationConstants.Category;

namespace NebulaNewsSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Articles = new List<Article>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Article> Articles { get; set; }
    }
}
