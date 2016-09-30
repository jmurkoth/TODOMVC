using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

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
            context.Response.OnStarting(() =>{
                if (!string.IsNullOrEmpty(_options?.HeaderName))
                {
                    context.Response.Headers.Add(_options.HeaderName, _options.HeaderValue);
                    _logger.LogInformation("***********************Invoked custom  HeaderMiddleWare***********************");
                }
                return Task.FromResult(0);
            });
            await _next(context);
        }
    }
}
