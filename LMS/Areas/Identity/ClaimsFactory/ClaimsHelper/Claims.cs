using LMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LMS.Areas.Identity.ClaimsFactory.ClaimsHelper
{
    public static class Claims
    {
        public static async Task<List<Claim>> GetClaims(IdentityUser user, ApplicationDbContext db)
        {
            var roleIds = await db.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId.ToString()).ToListAsync();
            var email = !string.IsNullOrEmpty(user.Email) ? user.Email : "";
            var fullName = string.IsNullOrEmpty(user.NormalizedUserName) ? "" : user.NormalizedUserName;
            var claims = new List<Claim>();
            claims.Add(new Claim("RoleIds", String.Join(",", roleIds)));
            claims.Add(new Claim("Email", email.ToString()));
            claims.Add(new Claim("FullName", fullName.ToString()));
            return claims;
        }
    }
}
