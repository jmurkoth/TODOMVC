using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Logging;

namespace Custom.Middleware
{
    /// <summary>
    /// Middle ware that adds a custom header 
    /// </summary>
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<HeaderMiddleware> _logger;
        private HeaderOptions _options;
        public HeaderMiddleware(RequestDelegate next, ILogger<HeaderMiddleware> logger, HeaderOptions options )
        {
            _next = next;
            _logger = logger;
            _options = options;
        }
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("***********************Invoked custom MiddleWare***********************");
            if (!string.IsNullOrEmpty( _options?.HeaderName))
            {
                context.Response.Headers.Add(_options.HeaderName, _options.HeaderValue);
            }
            await _next.Invoke(context);
            _logger.LogInformation("*******************Final Invoked custom MiddleWare *********************");
        }
    }
}
