using NebulaNewsSystem.Services.Data.Models.Articles;
using NebulaNewsSystem.Web.ViewModels.Article;
using NebulaNewsSystem.Web.ViewModels.Home;

namespace NebulaNewsSystem.Services.Data.Interfaces
{
    public interface IArticleService
    {
        // Last 3 or 5 article? Try and see
        Task<IEnumerable<IndexViewModel>> LastThreeArticlesAsync();
        Task<decimal> CalculateReadingTimeAsync(string articleText);
        Task CreateAsync(ArticleFormModel formModel, string authorId);
        Task<AllArticlesFilteredAndPagedServiceModel> AllAsync(AllArticlesQueryModel queryModel);
        Task<IEnumerable<ArticleAllViewModel>> AllByAuthorIdAsync (string authorId);
        Task<ArticleFormModel> GetArticleForEditByIdAsync(string articleId);

    }
}
