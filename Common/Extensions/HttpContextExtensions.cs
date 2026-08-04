using System.Security.Claims;

namespace Roznama.Common.Extensions
{
    public static class HttpContextExtensions
    {
        public static int GetUserOID(this HttpContext context)
        {
            var claim = context.User.FindFirst("userOID");
            return claim != null && int.TryParse(claim.Value, out var id)
                ? id
                : 0;
        }

        public static string GetUserRole(this HttpContext context)
        {
            return context.User.FindFirst(ClaimTypes.Role)?.Value ?? "";
        }
    }
}