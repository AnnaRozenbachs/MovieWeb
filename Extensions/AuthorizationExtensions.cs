using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace MovieWeb.Extensions
{
    public static class AuthorizationExtensions
    {
        public static bool IsAuthenticated(this ClaimsPrincipal user)
        {
            return user.Identity is null ? false : user.Identity.IsAuthenticated;
        }

        public static string UserId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            
        }
    }
}
