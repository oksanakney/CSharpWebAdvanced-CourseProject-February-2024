using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NebulaNewsSystem.Data.Models;
using System.Globalization;

namespace NebulaNewsSystem.Data.Configurations
{
    public class CategoryEntityConfiguration
    {
        //public void Configure(EntityTypeBuilder<Category> builder)
        //{
        //    builder.HasData(GenerateCategories());
        //}

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Politics"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Business and Economy"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Health and Wellness"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Entertainment and celebrities"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Sports"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 6,
                Name = "Science and Environment"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 7,
                Name = "Technology"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 8,
                Name = "Culture and Lifestyle"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 9,
                Name = "Education"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 10,
                Name = "Opinion and Editorial"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
