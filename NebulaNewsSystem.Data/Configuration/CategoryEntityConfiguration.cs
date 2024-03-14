using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NebulaNewsSystem.Data.Models.Configuration
{
    //TODO: Prove with internal
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

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
                Name = "Crime"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 8,
                Name = "Technology"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 9,
                Name = "Culture and Lifestyle"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 10,
                Name = "Education"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 11,
                Name = "Opinion and Editorial"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
