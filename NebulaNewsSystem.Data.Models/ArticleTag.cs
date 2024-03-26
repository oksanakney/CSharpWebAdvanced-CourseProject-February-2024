﻿namespace NebulaNewsSystem.Data.Models
{
    public class ArticleTag
    {
        public Guid ArticleId { get; set; }
        public Article Article { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
