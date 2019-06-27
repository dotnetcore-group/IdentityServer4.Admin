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
                .UseStartup<Startup>()
                .UseSerilogLogger();
    }
}
