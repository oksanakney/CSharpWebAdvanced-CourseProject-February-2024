using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using static NebulaNewsSystem.Common.EntityValidationConstants.Article;

namespace NebulaNewsSystem.Data.Models
{
    public class Article
    {       
        [Key]
        public Guid Id { get; set; }

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

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]  
        public virtual Author Author { get; set; } = null!;
        public List<Comment>? Comments { get; set; }
    }
}
