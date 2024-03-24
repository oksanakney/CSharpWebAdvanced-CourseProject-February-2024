using System.ComponentModel.DataAnnotations;

namespace NebulaNewsSystem.Web.ViewModels.Article
{
    public class ArticleAllViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        [Display(Name = "Created On")]
        public string PublicationDate { get; set; } = null!;

        [Display(Name = "Minutes")]
        public int ReadingTimeInMinutes { get; set; }

        [Display(Name ="Image Link")]
        public string ImageUrl { get; set; } = null!;       
    }
}
