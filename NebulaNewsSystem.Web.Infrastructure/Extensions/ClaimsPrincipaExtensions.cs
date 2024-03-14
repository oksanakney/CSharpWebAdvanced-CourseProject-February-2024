using System.Security.Claims;

namespace NebulaNewsSystem.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipaExtensions
    {
        // When you write an extension method, check in controller ->
        // string userId = this.User -> ClaimsPrincipal
        public static string GetId(this ClaimsPrincipal user)
        {
            //FindFirstValue can return null so we put string? in authorcontroller
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
