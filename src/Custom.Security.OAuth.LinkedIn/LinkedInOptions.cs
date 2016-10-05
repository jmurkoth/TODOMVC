using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Custom.Security.OAuth.LinkedIn
{
    public enum LinkedInProfileFields
    {
        [Description("id")]
        Id,
        [Description("email-address")]
        Email,
        [Description("first-name")]
        FirstName,
        [Description("last-name")]
        LastName,
        [Description("maiden-name")]
        MaidenName,
        [Description("formatted-name")]
        FormattedName,
        [Description("phonetic-first-name")]
        PhoneticFirstName,
        [Description("phonetic-last-name")]
        PhoneticLastName,
        [Description("formatted-phonetic-name")]
        FormattedPhoneticName,
        [Description("headline")]
        Headline,
        [Description("location")]
        Location,
        [Description("industry")]
        Industry,
        [Description("current-share")]
        CurrentShare,
        [Description("num-connections")]
        NumberofConnections,
        [Description("num-connections-capped")]
        NumberofConnectionsCapped,
        [Description("summary")]
        Summary,
        [Description("specialties")]
        Specialities,
        [Description("positions")]
        Positions,
        [Description("picture-url")]
        PictureUrl,
        [Description("picture-urls::(original)")]
        PictureUrlOriginal,
        [Description("site-standard-profile-request")]
        StdProfileRequest,
        [Description("api-standard-profile-request")]
        ApiStdProfileRequest,
        [Description("public-profile-url")]
        PublicProfileUrl
    }
    public class LinkedInOptions: OAuthOptions
    {
        public List<LinkedInProfileFields> ProfileFields { get; set; }

        public LinkedInOptions()
        {
            AuthenticationScheme = LinkedInDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath =LinkedInDefaults.CallbackPath;
            AuthorizationEndpoint = LinkedInDefaults.AuthorizationEndpoint;
            TokenEndpoint = LinkedInDefaults.TokenEndpoint;
            UserInformationEndpoint = LinkedInDefaults.UserInformationEndpoint;
            ProfileFields = new List<LinkedInProfileFields>();


        }
    }
}
