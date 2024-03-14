﻿using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.Data;
using NebulaNewsSystem.Web.ViewModels.Home;

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
        public async Task<IEnumerable<IndexViewModel>> LastThreeArticlesAsync()
        {
            IEnumerable<IndexViewModel> lastThreeArticles = await this.dbContext
                .Articles
                .OrderByDescending(ar => ar.PublicationDate)
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
    }
}
