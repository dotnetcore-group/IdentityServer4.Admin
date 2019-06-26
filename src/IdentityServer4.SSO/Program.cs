using IdentityServer4.Admin.BuildingBlock;
using IdentityServer4.SSO.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace IdentityServer4.SSO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer4 Admin SSO";

            var webHost = CreateWebHostBuilder(args).Build();

            webHost.MigrationAndSeedDataDB();

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilogLogger();
    }
}
