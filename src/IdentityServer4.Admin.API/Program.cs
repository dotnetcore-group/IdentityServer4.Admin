using IdentityServer4.Admin.BuildingBlock;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace IdentityServer4.Admin.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer4 Admin API";

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://+:5003", "http://+:5004")
                .UseStartup<Startup>()
                .UseSerilogLogger();
    }
}
