using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.Data;
using NebulaNewsSystem.Web.ViewModels.Category;

namespace NebulaNewsSystem.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly NebulaNewsDbContext dbContext;

        public CategoryService(NebulaNewsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ArticleSelectCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<ArticleSelectCategoryFormModel> allCategories = await dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new ArticleSelectCategoryFormModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allCategories;
        }
    }
}
