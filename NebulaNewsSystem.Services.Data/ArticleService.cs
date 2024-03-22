﻿using Microsoft.EntityFrameworkCore;
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
            // 1.Calculate the word count
            int wordCount = 
                articleText.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
            // 2.Estimate reading time in minutes
            int averageReadingSpeed = 200;
            double readingTimeMinutes = (double)averageReadingSpeed / wordCount;
            // 3.Convert to decimal(Hours)
            decimal readingTimeHours = (decimal)readingTimeMinutes / 60;

            return  readingTimeHours;
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

            return new AllArticlesFilteredAndPagedServiceModel()
            {
                //TotalArticlesCount = totalArticles,
                //Articles = allArticles
            };
        }
    }
}
