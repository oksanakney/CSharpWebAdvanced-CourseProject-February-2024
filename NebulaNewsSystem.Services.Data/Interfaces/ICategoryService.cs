namespace NebulaNewsSystem.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<ArticleSelectCategoryFormModel>> AllCategoriesAsync();
    }
}
