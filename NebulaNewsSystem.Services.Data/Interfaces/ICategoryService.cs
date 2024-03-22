﻿using NebulaNewsSystem.Web.ViewModels.Category;

namespace NebulaNewsSystem.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<ArticleSelectCategoryFormModel>> AllCategoriesAsync();
        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
