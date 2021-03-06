﻿using Microsoft.Extensions.DependencyInjection;
using ToDo.Core.Repos;
using Microsoft.Extensions.Logging;
using ToDo.Core.MondoDB;
using Custom.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ToDo.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using ToDo.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Service;
using Todo.MVC.Services;

namespace Todo.MVC
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                 Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //You add a middleware 
             services.AddMvc();
            //Add Entity Framework here
            //HACK: Current tooling Preview-1 does not support EF migration target a class library
            // hence specifying the migration assembly as web app and that is why we end up having migrations
            // added to the web app instead of the class library that has the context
           services.AddEntityFramework()
               .AddDbContext<ToDoDataContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("TODOConnStr"), b => b.MigrationsAssembly("Todo.MVC")));
            services.AddEntityFramework()
                .AddDbContext<ToDoDataContext>(opts => opts.UseInMemoryDatabase());
            //Add the identity provider
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ToDoDataContext>()
                    .AddDefaultTokenProviders();

            // DI in action using SQL Repo
           services.AddTransient<IToDoRepository, SQLToDoRepository>();
           services.AddScoped<IUserService , UserService>();
            // services.AddScoped<MongoContext>();
            // services.AddSingleton<IToDoRepository, MongoToDoRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
          // without static files not event html or images will be served up
            app.UseStaticFiles();
            // Need to hook this up before the other middleware is hooked up
            // this does not use the extension method
            // app.UseMiddleware<HeaderMiddleware>(new HeaderOptions {HeaderName="X-Powered-By", HeaderValue="ASPNET_CORE" });
            //using the extension method
            //app.UseCustomHeader(new HeaderOptions { HeaderName = "X-Powered-By", HeaderValue = "ASPNET_CORE" });
            // Via diagnostics.. shows the new yellow screen of death

            // Need to add .adddebug and  console logging level should watch if you want debug messages to popup
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(LogLevel.Debug);
                loggerFactory.AddDebug();

                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            //Note order is important use identity has to come before you call 
            // external login  provider else it won't work
            app.UseIdentity();
            app.UseGoogleAuthentication(new GoogleOptions()
            {
                ClientId = Configuration["OAuth:Google:clientId"],
                ClientSecret = Configuration["OAuth:Google:clientSecret"],
                CallbackPath = "/signin-google"

            });
            //Add the facebook authentication
            app.UseFacebookAuthentication(new FacebookOptions()
            {
                AppId = Configuration["OAuth:Facebook:appId"],
                AppSecret = Configuration["OAuth:Facebook:appSecret"]


            });
            //Add the Microsoft Authentication
            app.UseMicrosoftAccountAuthentication(new MicrosoftAccountOptions()
            {
                ClientId = Configuration["OAuth:Microsoft:clientId"],
                ClientSecret = Configuration["OAuth:Microsoft:clientSecret"]
                //CallbackPath="/signin-microsoft"
            });
           
           app.UsePipelineTimer();
            app.UseMvc(routes =>
             routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}/{type?}"
                 ));

          
           

        }

    }
}
