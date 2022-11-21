using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{

    /// <summary>
    /// Entry point of the web application and creates an instance of IWebHost which hosts web application.
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Main method to build and to run the web application
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Called the startup class in the Startup.cs and requests IHostBuilder to create the default builder for startup
        /// </summary>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }

}