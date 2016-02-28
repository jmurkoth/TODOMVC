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
using ToDo.Core.EF;
using ToDo.Core.MondoDB;
using Custom.Middleware;

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
            //Add Entity Framework here
            //services.AddEntityFramework()
            //    .AddSqlServer()
            //    .AddDbContext<ToDoDataContext>();

            // DI in action using SQL Repo
            //  services.AddSingleton<IToDoRepository, SQLToDoRepository>();
             services.AddScoped<MongoContext>();
             services.AddSingleton<IToDoRepository, MongoToDoRepository>();
           // services.AddSingleton<IToDoRepository, InMemoryToDoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // Here we are configuring the middleware for running in IIS
            app.UseIISPlatformHandler();
            // without static files not event html or images will be served up
            app.UseStaticFiles();
            // Need to hook this up before the other middleware is hooked up
            // this does not use the extension method
            // app.UseMiddleware<HeaderMiddleware>(new HeaderOptions {HeaderName="X-Powered-By", HeaderValue="ASPNET_CORE" });
            //using the extension method
            app.UseCustomHeader(new HeaderOptions { HeaderName = "X-Powered-By", HeaderValue = "ASPNET_CORE" });
            loggerFactory.MinimumLevel = LogLevel.Debug;
            // Via diagnostics.. shows the new yellow screen of death
            //TODO: show it only if the environment is development
            // Need to add .adddebug and  console logging level should watch if you want debug messages to popup
            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug(); 

            app.UseDeveloperExceptionPage();
            app.UsePipelineTimer();
            app.UseMvc(routes =>
             routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}/{type?}"
                 ));

          
           

        }

        // Entry point for the application.
        public static void Main(string[] args)
        {
            WebApplication.Run<Startup>(args);
        }
    }
}
