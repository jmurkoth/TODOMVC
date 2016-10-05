using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Custom.Security.OAuth.LinkedIn;
using System.Collections.Generic;
using System.Linq;

namespace Custom.Security.OAuth.LinkedIn
{
    internal class LinkedInHandler : OAuthHandler<LinkedInOptions>
    {

        public LinkedInHandler(HttpClient backchannel) : base(backchannel)
        {
        }

        protected override async Task<AuthenticationTicket> CreateTicketAsync(
           ClaimsIdentity identity,
           AuthenticationProperties properties,
           OAuthTokenResponse tokens)
        {
            List<string> userOptionList = new List<string>();
            var userEndPoint = Options.UserInformationEndpoint;
            // Default values that we get by default
            List<LinkedInProfileFields> defaultFields = new List<LinkedInProfileFields> {LinkedInProfileFields.Id, LinkedInProfileFields.Email, LinkedInProfileFields.FirstName };
            Options.ProfileFields.AddRange(defaultFields);
            Options.ProfileFields?.ForEach(c => userOptionList.Add(c.GetDescription()));
            var userOptions = string.Join(",", userOptionList.Distinct());
            if (userEndPoint.EndsWith("~") && userOptions.Length>0)
            {
                userEndPoint =  $"{userEndPoint}:({userOptions })";
            }
            var request = new HttpRequestMessage(HttpMethod.Get, userEndPoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
            request.Headers.Add("x-li-format", "json");

            var response = await Backchannel.SendAsync(request, Context.RequestAborted);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occurred when retrieving user information ({response.StatusCode}). Please check if the authentication information is correct and the corresponding LinkedIn API is enabled.");
            }
            var str = await response.Content.ReadAsStringAsync();
            // convert to a json object
            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
            // retrieve the different pieces of user info and set them as claims
            identity.AddClaimCustom(ClaimTypes.NameIdentifier, LinkedInHelper.GetId(payload), Options.ClaimsIssuer)
                    .AddClaimCustom(ClaimTypes.Name, LinkedInHelper.GetFormattedName(payload), Options.ClaimsIssuer)
                    .AddClaimCustom(ClaimTypes.Email, LinkedInHelper.GetEmail(payload), Options.ClaimsIssuer)
                    .AddClaimCustom(ClaimTypes.GivenName, LinkedInHelper.GetFirstName(payload), Options.ClaimsIssuer)
                    .AddClaimCustom(ClaimTypes.Surname, LinkedInHelper.GetLastName(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/formattedname", LinkedInHelper.GetFormattedName(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/phoneticfirstname", LinkedInHelper.GetPhoneticFirstName(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/phoneticlastname", LinkedInHelper.GetPhoneticLastName(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/formattedphoneticname", LinkedInHelper.GetFormattedPhoneticName(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/headline", LinkedInHelper.GetHeadLine(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/location", LinkedInHelper.GetLocation(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/industry", LinkedInHelper.GetIndustry(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/currentshare", LinkedInHelper.GetCurrentShare(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/numconnections", LinkedInHelper.GetNumberofConnections(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/numconnectionscapped", LinkedInHelper.GetIsNumberofConnectionCapped(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/summary", LinkedInHelper.GetSummary(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/specialities", LinkedInHelper.GetSpecialities(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/positions", LinkedInHelper.GetPositions(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/pictureurl", LinkedInHelper.GetPictureUrl(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/pictureurloriginal", LinkedInHelper.GetPictureUrlOriginal(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/sitestdprofilerequest", LinkedInHelper.GetSiteStandardProfileRequest(payload), Options.ClaimsIssuer)
                    .AddClaimCustom("http://linkedin.com/apistdprofilerequest", LinkedInHelper.GetApiStdProfileRequest(payload), Options.ClaimsIssuer)
                     .AddClaimCustom("http://linkedin.com/publicprofileurl", LinkedInHelper.GetPublicProfileUrl(payload), Options.ClaimsIssuer);
                  
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, properties, Options.AuthenticationScheme);
            var context = new OAuthCreatingTicketContext(ticket, Context, Options, Backchannel, tokens, payload);
            await Options.Events.CreatingTicket(context);

            return context.Ticket;
        }
    }
}