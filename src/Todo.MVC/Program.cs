using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Reflection;

namespace Todo.MVC
{
    public class Program
    {
        // Entry point for the application.
        public static void Main(string[] args)
        {
            var assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
               // .UseStartup<Startup>()-- Rather than using a specific startup ; making it dynamic
                .UseStartup(assemblyName)
                .Build();

            host.Run();
        }
    }
}
