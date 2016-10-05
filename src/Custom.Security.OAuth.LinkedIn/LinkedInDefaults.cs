using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custom.Security.OAuth.LinkedIn
{
    public static class LinkedInDefaults
    {
        public const string AuthenticationScheme = "LinkedIn";
        public const string CallbackPath = "/signin-linkedin";
        public const string AuthorizationEndpoint = "https://www.linkedin.com/uas/oauth2/authorization";
        public const string TokenEndpoint = "https://www.linkedin.com/uas/oauth2/accessToken";
        public const string UserInformationEndpoint = "https://api.linkedin.com/v1/people/~";
    }
}
