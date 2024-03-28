using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NebulaNewsSystem.Common.EntityValidationConstants.Author;

namespace NebulaNewsSystem.Data.Models
{
    public class Author
    {
        public Author()
        {
            Id = Guid.NewGuid();
            this.WrittenArticles = new List<Article>();
            this.CommentsWrittenByAuthor = new List<Comment>();
        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;       

        public ICollection<Article> WrittenArticles { get; set; }
        public ICollection<Comment> CommentsWrittenByAuthor { get; set; }
    }
}
