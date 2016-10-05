using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.DataProtection;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Custom.Security.OAuth.LinkedIn
{
    public class LinkedInMiddleware : OAuthMiddleware<LinkedInOptions>
    {
        private readonly RequestDelegate _next;
        private ILogger<LinkedInMiddleware> _logger;
        public LinkedInMiddleware(
                        RequestDelegate next,
                        IDataProtectionProvider dataProtectionProvider,
                        ILoggerFactory loggerFactory,
                        UrlEncoder encoder,
                        IOptions<SharedAuthenticationOptions> sharedOptions,
                        IOptions<LinkedInOptions> options)
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            if (dataProtectionProvider == null)
            {
                throw new ArgumentNullException(nameof(dataProtectionProvider));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (encoder == null)
            {
                throw new ArgumentNullException(nameof(encoder));
            }

            if (sharedOptions == null)
            {
                throw new ArgumentNullException(nameof(sharedOptions));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override AuthenticationHandler<LinkedInOptions> CreateHandler()
        {
            return new LinkedInHandler(Backchannel);
        }
    }
}
