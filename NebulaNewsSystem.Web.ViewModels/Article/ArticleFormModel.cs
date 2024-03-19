using NebulaNewsSystem.Web.ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using static NebulaNewsSystem.Common.EntityValidationConstants.Article;

namespace NebulaNewsSystem.Web.ViewModels.Article
{
    public class ArticleFormModel
    {
        public ArticleFormModel()
        {
            this.Categories = new HashSet<ArticleSelectCategoryFormModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;

        public string PublicationDate { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ArticleSelectCategoryFormModel> Categories { get; set; }
    }
}
