using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static NebulaNewsSystem.Common.EntityValidationConstants.Author;

namespace NebulaNewsSystem.Data.Models
{
    public class Author
    {
        public Author()
        {
            this.Articles = new List<Article>();
        }
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(PhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;

        //Relation to user
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public List<Article> Articles { get; set; }
    }
}
