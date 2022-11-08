using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Access_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:8081/"); //VERY IMPORTANT TO USE * TO ALLOW CONNECTIONS FROM OTHER SERVERS INSTEAD OF LOCALHOST!!!!!
                });
    }
}
