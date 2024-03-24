using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NebulaNewsSystem.Data.Models;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Services.Data.Models.Articles;
using NebulaNewsSystem.Web.Data;
using NebulaNewsSystem.Web.ViewModels.Article;
using NebulaNewsSystem.Web.ViewModels.Article.Enums;
using NebulaNewsSystem.Web.ViewModels.Home;
using System.Globalization;
using System.Linq;
using static NebulaNewsSystem.Common.EntityValidationConstants.Article;

namespace NebulaNewsSystem.Services.Data
{
    public class ArticleService : IArticleService
    {
        // In services I have no inject the Db context, service communicates with db

        private readonly NebulaNewsDbContext dbContext;

        //Inversion of control container na asp.net, because in program.cs I have dbContext registrated
        //I can use it where I want
        public ArticleService(NebulaNewsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<decimal> CalculateReadingTimeAsync(string articleText)
        {
            // Simulate an asynchronous operation, like fetching data from a database or API
            await Task.Delay(100); // For example, delay for 100 milliseconds

            // Your existing synchronous logic
            int wordCount =
                articleText.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;

            int averageReadingSpeed = 200;
            int readingTimeMinutes = (int)(averageReadingSpeed / wordCount);            

            return readingTimeMinutes;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeArticlesAsync()
        {
            IEnumerable<IndexViewModel> lastThreeArticles = await this.dbContext
                .Articles
                .OrderBy(ar => ar.Title)
                .Take(3)
                .Select(ar => new IndexViewModel()
                {
                    Id = ar.Id.ToString(),
                    Title = ar.Title,
                    ImageUrl = ar.ImageUrl
                })
                .ToArrayAsync();

            return lastThreeArticles;
        }

        public async Task CreateAsync(ArticleFormModel formModel, string authorId)
        {
            //DateTime publicationDate = DateTime.UtcNow;
            //if (!DateTime.TryParseExact(
            //    formModel.PublicationDate,
            //    DateFormat,
            //    CultureInfo.InvariantCulture,
            //    DateTimeStyles.None,
            //    out publicationDate))
           
            // It is easier with automapper
            Article newArticle = new Article()
            {
                Title = formModel.Title,
                Content = formModel.Content,
                ImageUrl = formModel.ImageUrl,                
                CategoryId = formModel.CategoryId,
                AuthorId = Guid.Parse(authorId)
            };

            await this.dbContext.AddAsync(newArticle);
            await this.dbContext.SaveChangesAsync();

            
        }

        public async Task<AllArticlesFilteredAndPagedServiceModel> AllAsync(AllArticlesQueryModel queryModel)
        {
            // it permits us to build expression tree on Query
            IQueryable<Article> articlesQuery = this.dbContext
                .Articles
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                articlesQuery = articlesQuery
                    .Where(a => a.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";
                articlesQuery = articlesQuery
                    .Where(h => EF.Functions.Like(h.Title, wildCard) ||
                                EF.Functions.Like(h.Content, wildCard));
            }

            // Podrezdam gi 
            articlesQuery = queryModel.ArticleSorting switch
            {
                ArticleSorting.Newest => articlesQuery
                    .OrderBy(a => a.PublicationDate),
                ArticleSorting.Oldest => articlesQuery
                    .OrderByDescending(a => a.PublicationDate),

               _ => articlesQuery
                    .OrderBy(a => a.Title != null)
                    .ThenByDescending(a => a.PublicationDate)

            };

            //Paginantion

            IEnumerable<ArticleAllViewModel> allArticles = await articlesQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.ArticlesPerPage)
                .Take(queryModel.ArticlesPerPage)
                .Select(a => new ArticleAllViewModel
                {
                    Id = a.Id.ToString(),
                    Title = a.Title,
                    Content = a.Content,
                    ImageUrl = a.ImageUrl

                })
                .ToArrayAsync();// materializiram
            int totalArticles = articlesQuery.Count();

            return new AllArticlesFilteredAndPagedServiceModel()
            {
                TotalArticlesCount = totalArticles,
                Articles = allArticles
            };
        }

        public async Task<IEnumerable<ArticleAllViewModel>> AllByAuthorIdAsync(string authorId)
        {
            IEnumerable<ArticleAllViewModel> allAuthorArticles = await this.dbContext
                .Articles
                .Where(a => a.AuthorId.ToString() == authorId)
                .Select(a => new ArticleAllViewModel()
                {
                    Id = a.Id.ToString(),
                    Title = a.Title,
                    Content = a.Content,
                    ImageUrl = a.ImageUrl,
                    PublicationDate = a.PublicationDate.ToString(),
                })
                .ToArrayAsync();

            return allAuthorArticles;
        }
    }
}
