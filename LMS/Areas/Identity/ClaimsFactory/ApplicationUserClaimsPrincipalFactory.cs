using LMS.Areas.Identity.ClaimsFactory.ClaimsHelper;
using LMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace LMS.Areas.Identity.ClaimsFactory
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserClaimsPrincipalFactory(
                                                    UserManager<IdentityUser> userManager,
                                                    RoleManager<IdentityRole> roleManager,
                                                    IOptions<IdentityOptions> optionsAccessor,
                                                    ApplicationDbContext db
                                                    )
                                                    : base(userManager, roleManager, optionsAccessor)
        {
            _db = db;
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            //identity.AddClaim(new Claim("UserFirstName", user.FirstName ?? ""));
            //identity.AddClaim(new Claim("UserLastName", user.LastName ?? ""));
            identity.AddClaims(await Claims.GetClaims(user, _db));
            return identity;
        }

    }
}
