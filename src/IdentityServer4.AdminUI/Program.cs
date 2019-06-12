using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace IdentityServer4.AdminUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer4 AdminUI";

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://+:5001", "http://+:5000")
                .UseStartup<Startup>();
    }
}
