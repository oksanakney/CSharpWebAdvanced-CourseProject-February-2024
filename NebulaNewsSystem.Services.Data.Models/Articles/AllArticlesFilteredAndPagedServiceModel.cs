using NebulaNewsSystem.Web.ViewModels.Article;

namespace NebulaNewsSystem.Services.Data.Models.Articles
{
    public class AllArticlesFilteredAndPagedServiceModel
    {
        public AllArticlesFilteredAndPagedServiceModel()
        {
            this.Articles = new HashSet<ArticleAllViewModel>();
        }
        public int TotalArticlesCount { get; set; }
        public IEnumerable<ArticleAllViewModel> Articles { get; set; }
    }
}
