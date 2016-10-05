using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.OAuth;
using Custom.Security.OAuth.LinkedIn;
using Microsoft.Extensions.Configuration;
namespace Todo.MVC
{
    public  static class Helper
    {
        public static IApplicationBuilder UseTODOMVCOAuthAuthentication(this IApplicationBuilder app, IConfiguration Configuration)
        {
            app.UseGoogleAuthentication(new GoogleOptions()
            {
                ClientId = Configuration["OAuth:Google:clientId"],
                ClientSecret = Configuration["OAuth:Google:clientSecret"],
                CallbackPath = "/signin-google",
                Events = new OAuthEvents
                {
                    OnRemoteFailure = context => {
                        context.Response.Redirect($"/account/oautherror/{context.Failure}");
                        context.HandleResponse();
                        return Task.FromResult(0);
                    }

                }

            });
            //Add the facebook authentication
            app.UseFacebookAuthentication(new FacebookOptions()
            {
                AppId = Configuration["OAuth:Facebook:appId"],
                AppSecret = Configuration["OAuth:Facebook:appSecret"],
                Events = new OAuthEvents
                {
                    OnRemoteFailure = context => {
                        context.Response.Redirect($"/account/oautherror/{context.Failure?.Message}");
                        context.HandleResponse();
                        return Task.FromResult(0);
                    }

                }


            });
            //Add the Microsoft Authentication
            app.UseMicrosoftAccountAuthentication(new MicrosoftAccountOptions()
            {
                ClientId = Configuration["OAuth:Microsoft:clientId"],
                ClientSecret = Configuration["OAuth:Microsoft:clientSecret"],
                CallbackPath = "/signin-microsoft"
            });
            // custom Linked in oAuth Middleware
            app.UseLinkedInAuthentication(new LinkedInOptions()
            {
                ClientId = Configuration["OAuth:LinkedIn:clientId"],
                ClientSecret = Configuration["OAuth:LinkedIn:clientSecret"],
                ProfileFields = new List<LinkedInProfileFields> {
                                        LinkedInProfileFields.Email,
                                        LinkedInProfileFields.Id,
                                        LinkedInProfileFields.PublicProfileUrl
                                },
                Events = new OAuthEvents
                {
                    OnRemoteFailure = context => {
                        context.Response.Redirect($"/account/oautherror/{context.Failure?.Message}");
                        context.HandleResponse();
                        return Task.FromResult(0);
                    }

                }
            });
            return app;
        }
    }
}
