using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NebulaNewsSystem.Common.EntityValidationConstants.Author;

namespace NebulaNewsSystem.Data.Models
{
    public class Author
    {
        public Author()
        {
            this.Articles = new List<Article>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(PhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;       

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string? ReaderId { get; set; }

        [ForeignKey(nameof(ReaderId))]
        public virtual ApplicationUser? Reader { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
