using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NebulaNewsSystem.Data.Models;
using System;

namespace NebulaNewsSystem.Data.Configurations.SeedCofiguration
{
    public class SeedArticlesEntityConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(GenerateArticles());
        }

        private Article[] GenerateArticles()
        {
            List<Article> articles = new List<Article>();

            Article article;

            string publicationDate1 = "12.03.2024 22:00";

            article = new Article()
            {
                ArticleId = Guid.Parse("550f78bf-9c45-4fa1-9a1e-4af3a5192be6"),
                Title = "A 17-year-old who drove a Mercedes both without a license and with fake license plates arrested",
                Content = "A 17-year-old unlicensed driver of a Mercedes was detained last night by Dupnitsa's policemen. They carried out the inspection in the area of Sapareva Banya, and also found that the inspected car had registration plates issued for another vehicle. A quick police investigation was initiated in the Dupnitsa Intelligence Department, the prosecutor's office was notified.",
                ImageUrl = "https://i.id24.bg/i/1616547.jpg",
                PublicationDate = DateTime.ParseExact(publicationDate1, "dd.MM.yyyy HH:mm", null),
                CategoryId = 7,
                AuthorId = Guid.Parse("439455A8-590B-4FD3-A3F6-5CF16729DBB2")
            };
            articles.Add(article);


            string publicationDate2 = "12.03.2024 22:30";

            article = new Article()
            {
                ArticleId = Guid.Parse("49cde94c-3f90-4f95-8e91-a751aa2b7af4"),
                Title = "The results of the competitions for principals of schools in Dupnitsa are known",
                Content = "The results of the competitions for principals of three Dupnitsa's schools are known now. Lyubomir Georgiev was elected as the director of \"Hristo Botev\" Profesional Gymnasium. He is a physical education teacher, baseball coach and former city councilman. The incumbent Gergana Milenkova dropped out of the race for the post. In head of secondary language school \"St. Paisiy Hilendarski\" remains Anelia Yordanova. She took over the leadership of the largest drilling school two years ago until a competition was held. Director of General Educational School \"St. Kliment Ohridski\" remains Juliana Borisova, who was the only candidate.",
                ImageUrl = "https://static.bnr.bg/gallery/cr/3ae7c802129b9a9ae5af2da27e6a183a.jpg",
                PublicationDate = DateTime.ParseExact(publicationDate2, "dd.MM.yyyy HH:mm", null),
                CategoryId = 10,
                AuthorId = Guid.Parse("439455A8-590B-4FD3-A3F6-5CF16729DBB2")
            };
            articles.Add(article);

            string publicationDate3 = "12.03.2024 23:00";

            article = new Article()
            {
                ArticleId = Guid.Parse("3c74cdaa-71b0-4789-89e0-93c72fd2e8a9"),
                Title = "The municipal council of Dupnitsa meets because of the mineral water in Bistritsa",
                Content = "The transformation of the mineral water borehole in the village of Bistrica into an object of primary importance for the municipality will be the subject of debate at an extraordinary session in Dupnitsa. The report was entered by the councilor from \"Voice of the People\" Gichka Mihailova. We recall that she would alarm that the firm involved in the study was considering a withdrawal.",
                ImageUrl = "https://4vlast-bg.com/wp-content/uploads/2023/12/403389284_682223740702741_5157933701577735441_n.jpg",
                PublicationDate = DateTime.ParseExact(publicationDate3, "dd.MM.yyyy HH:mm", null),
                CategoryId = 1,
                AuthorId = Guid.Parse("439455A8-590B-4FD3-A3F6-5CF16729DBB2")
            };
            articles.Add(article);

            return articles.ToArray();
        }
    }
}
