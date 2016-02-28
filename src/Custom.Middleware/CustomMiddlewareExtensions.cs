using Microsoft.AspNet.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custom.Middleware
{
    /// <summary>
    /// Extension class that allow you to u
    /// </summary>
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomHeader(this IApplicationBuilder builder, HeaderOptions options)
        {
            return builder.UseMiddleware<HeaderMiddleware>(options);
        }
        public static IApplicationBuilder UsePipelineTimer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PipelineTimerMiddleware>();
        }
    }
}
