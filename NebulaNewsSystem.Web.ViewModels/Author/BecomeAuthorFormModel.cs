using System.ComponentModel.DataAnnotations;
using static NebulaNewsSystem.Common.EntityValidationConstants.Author;

namespace NebulaNewsSystem.Web.ViewModels.Author
{
    public class BecomeAuthorFormModel
    {
        [Required]
        [RegularExpression(PhoneNumberRegEx)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
