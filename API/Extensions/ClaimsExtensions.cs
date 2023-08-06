using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUsername(this ClaimsPrincipal User){
            return User.FindFirstValue(ClaimTypes.Name);
        }
       
    }
}