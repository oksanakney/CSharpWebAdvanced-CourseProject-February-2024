using Microsoft.AspNetCore.Identity;

namespace NebulaNewsSystem.Data.Models
{
    /// <summary>
    /// This is custom user class that works with the default ASP.NET Core Identity.
    /// You can add additional info to the built-in users.
    /// </summary>
    public class User : IdentityUser<Guid>
    {
        public ICollection<Comment>? Comments { get; set; }
    }
}
