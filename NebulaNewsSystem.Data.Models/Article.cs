using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static NebulaNewsSystem.Common.EntityValidationConstants.Article;

namespace NebulaNewsSystem.Data.Models
{
    public class Article
    {
        public Article()
        {
            this.Comments = new List<Comment>();
        }

        [Key]
        public Guid ArticleId { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        public DateTime PublicationDate { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; } = null!;
        List<Comment> Comments { get; set; }
    }
}
