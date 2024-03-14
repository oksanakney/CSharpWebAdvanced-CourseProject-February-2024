using NebulaNewsSystem.Web.ViewModels.Home;

namespace NebulaNewsSystem.Services.Data.Interfaces
{
    public interface IArticleService
    {
        // Last 3 or 5 article? Try and see
        Task<IEnumerable<IndexViewModel>> LastThreeArticlesAsync();
    }
}
