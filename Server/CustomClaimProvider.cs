using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace SampleApp.Server;

public class CustomClaimProvider : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        // Add extra/custom claims here
        // You can call a db, make an API call, etc. to get the extra claims

        var extraIdentity = new ClaimsIdentity();
        extraIdentity.AddClaim(new Claim("permission", "CanRead"));
        extraIdentity.AddClaim(new Claim("permission", "CanEdit"));
        extraIdentity.AddClaim(new Claim("permission", "CanDelete"));

        // Attach to current identity
        principal.AddIdentity(extraIdentity);
        
        return Task.FromResult(principal);
    }
}