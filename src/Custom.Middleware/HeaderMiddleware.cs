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
        
        public HeaderMiddleware(RequestDelegate next, ILogger<HeaderMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("***********************Invoked custom MiddleWare***********************");
            context.Response.Headers.Add("Powered By", "ASPNET CORE");
            await _next.Invoke(context);
            _logger.LogInformation("*******************Final Invoked custom MiddleWare *********************");
        }
    }
}
