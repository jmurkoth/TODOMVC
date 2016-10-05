using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Custom.Security.OAuth.LinkedIn
{

    public static class LinkedInAppBuilderExtensions
    {
        public static IApplicationBuilder UseLinkedInAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            return app.UseMiddleware<LinkedInMiddleware>();
        }
        public static IApplicationBuilder UseLinkedInAuthentication(this IApplicationBuilder app, LinkedInOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<LinkedInMiddleware>(Options.Create(options));
        }

    }
    
}
