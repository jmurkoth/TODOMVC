using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Core.Repos;
using Microsoft.Extensions.Logging;

namespace TodoMVCRC1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //You add a middleware 
            services.AddMvc();
            // DI in action
            services.AddSingleton<IToDoRepository, InMemoryToDoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;

            // Need to add .adddebug and  console logging level should watch if you want debug messages to popup
            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug(); 
            // Here we are configuring the middleware
            app.UseIISPlatformHandler();
            app.UseMvc(routes =>
             routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}/{type?}"
                 ));
            // without static files not event html or images will be served up
            app.UseStaticFiles();
            
           
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
