using NebulaNewsSystem.Web.ViewModels.Article.Enums;
using System.ComponentModel.DataAnnotations;
using static NebulaNewsSystem.Common.GeneralApplicationConstants;

namespace NebulaNewsSystem.Web.ViewModels.Article
{
    public class AllArticlesQueryModel
    {
        public AllArticlesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.ArticlesPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Articles = new HashSet<ArticleAllViewModel>();
        }
        public string? Category { get; set; }

        public  string? SearchString { get; set; }

        [Display(Name = "Sort Articles By")]
        public ArticleSorting ArticleSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Articles On Page")]
        public int ArticlesPerPage { get; set; }

        public  int TotalArticles { get; set; }
        public string PublicationDate { get; set; } = null!;

        public  IEnumerable<string> Categories { get; set; }

        public IEnumerable<ArticleAllViewModel> Articles { get; set; }


    }
}
