using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Custom.Security.OAuth.LinkedIn
{
    public class LinkedInHelper
    {
        internal static string GetApiStdProfileRequest(JObject payload) => payload?.Value<string>("api-standard-profile-request");
        internal static string GetId(JObject payload) => payload?.Value<string>("id");
        internal static string GetCurrentShare(JObject payload) => payload?.Value<string>("currentShare");
        internal static string GetEmail(JObject payload) => payload?.Value<string>("emailAddress");
        internal static string GetFirstName(JObject payload) => payload?.Value<string>("firstName");
        internal static string GetFormattedName(JObject payload) => payload?.Value<string>("formattedName");
        internal static string GetFormattedPhoneticName(JObject payload) => payload?.Value<string>("formattedPhoneticName");
        internal static string GetHeadLine(JObject payload) => payload?.Value<string>("headline");
        internal static string GetIndustry(JObject payload) => payload?.Value<string>("industry");
        internal static string GetLastName(JObject payload) => payload?.Value<string>("lastName");
        internal static string GetLocation(JObject payload) => payload?.Value<string>("location");
        internal static string GetMaidenName(JObject payload) => payload?.Value<string>("maidenName");
        internal static string GetNumberofConnections(JObject payload) => payload?.Value<string>("numConnections");
        internal static string GetIsNumberofConnectionCapped(JObject payload) => payload?.Value<string>("numConnectionsCapped");
        internal static string GetPhoneticFirstName(JObject payload) => payload?.Value<string>("phoneticFirstName");
        internal static string GetPhoneticLastName(JObject payload) => payload?.Value<string>("phoneticLastName");
        internal static string GetPictureUrl(JObject payload) => payload?.Value<string>("pictureUrl");
        internal static string GetPictureUrlOriginal(JObject payload) => payload?.Value<string>("picture-urls::(original)");
        internal static string GetPositions(JObject payload) => payload?.Value<string>("positions");
        internal static string GetPublicProfileUrl(JObject payload) => payload?.Value<string>("publicProfileUrl");
        internal static string GetSiteStandardProfileRequest(JObject payload) => payload?.Value<string>("siteStandardProfileRequest");
        internal static string GetSpecialities(JObject payload) => payload?.Value<string>("specialties");
        internal static string GetSummary(JObject payload) => payload?.Value<string>("summary");


    }
}
