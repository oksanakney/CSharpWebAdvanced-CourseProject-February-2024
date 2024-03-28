using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using static NebulaNewsSystem.Common.EntityValidationConstants.Article;

namespace NebulaNewsSystem.Data.Models
{
    public class Article
    {
        public Article()
        {
            Id = Guid.NewGuid();
            this.ArticleTags = new List<ArticleTag>();
            this.Comments = new List<Comment>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public bool IsPublished { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = null!;
        
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<ArticleTag> ArticleTags { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
