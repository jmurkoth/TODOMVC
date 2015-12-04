using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Localization;
using TodoMVCRC1.Models;
using Microsoft.Extensions.Localization;
using TodoMVCRC1.Resources;
using TodoMVCRC1.Misc;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TodoMVCRC1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {//

            //services.TryAdd(new ServiceDescriptor(
            //    typeof(IStringLocalizerFactory),
            //    typeof(JsonStringLocalizerFactory),
            //    ServiceLifetime.Singleton));
            services.AddLocalization(opt => opt.ResourcesPath = "resources"); // Path to localized resources

            services.AddMvc()
                    .AddViewLocalization()
                    .AddDataAnnotationsLocalization(); //Added the localization
            services.AddSingleton<IToDoRepository, InMemoryToDoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            // order matters . This needs to happen before we say use MVC
            app.UseIISPlatformHandler();
            app.UseRequestLocalization(new RequestCulture("hi-IN"));
            
            app.UseMvc(routes =>
             routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                 ));
            app.UseStaticFiles();


        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
