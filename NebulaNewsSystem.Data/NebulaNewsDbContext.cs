﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Data.Configurations.SeedCofiguration;
using NebulaNewsSystem.Data.Models;
using System.Reflection;



namespace NebulaNewsSystem.Web.Data
{

    public class NebulaNewsDbContext : IdentityDbContext
    {
        private readonly bool seedDb;

        public NebulaNewsDbContext(DbContextOptions<NebulaNewsDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;


        // TODO: TRY TO REMOVE THIS TO Article, cooment Enity Config
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(NebulaNewsDbContext)) ?? 
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            builder.ApplyConfiguration(new SeedArticlesEntityConfiguration());
            builder.ApplyConfiguration(new SeedCategoriesEntityConfiguration());
            builder.ApplyConfiguration(new SeedCommentsEntityConfiguration());

            if (this.seedDb)
            {
                builder.ApplyConfiguration(new SeedArticlesEntityConfiguration());
                builder.ApplyConfiguration(new SeedCategoriesEntityConfiguration());
                builder.ApplyConfiguration(new SeedCommentsEntityConfiguration());
            }

            base.OnModelCreating(builder);
        }
    }
}
