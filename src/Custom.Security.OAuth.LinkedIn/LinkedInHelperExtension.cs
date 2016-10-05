using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Custom.Security.OAuth.LinkedIn
{
    public static class LinkedInHelperExtension
    {
        public static ClaimsIdentity AddClaimCustom(this ClaimsIdentity identity, string type, string value, string issuer)
        {
            if( identity==null)
            {
                throw new ArgumentNullException("Identity is null");
            }
            if(!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(value))
            {
                identity.AddClaim(new Claim(type, value, ClaimValueTypes.String, issuer?? ClaimsIdentity.DefaultIssuer));
            }
            return identity;
        }
    }
}
