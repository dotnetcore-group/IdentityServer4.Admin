using Microsoft.AspNetCore.Hosting;
using IdentityServer4.Admin.BuildingBlock;
using System;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using IdentityServer4.Admin.Identity;
using IdentityServer4.Admin.Data.Database;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Linq;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Stores;

namespace IdentityServer4.SSO.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrationAndSeedDataDB(this IWebHost webHost)
        {
            webHost.MigrateDbContext<IDS4DbContext>(EnsureSeedIDS4Data)
                .MigrateDbContext<AppIdentityDbContext>(EnsureSeedIdentityData)
                .MigrateDbContext<EventStoreContext>(null);

            return webHost;
        }

        private static void EnsureSeedIdentityData(AppIdentityDbContext context, IServiceProvider sp)
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var userManager = sp.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = sp.GetRequiredService<RoleManager<ApplicationRole>>();



            // Create admin role
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new ApplicationRole { Name = "Administrator" };

                roleManager.CreateAsync(role).Wait();

                // Create admin user
                if (userManager.FindByNameAsync(configuration.GetValue("DefaultUser:UserName", "")).Result != null) return;

                var user = new ApplicationUser
                {
                    UserName = configuration.GetValue("DefaultUser:UserName", ""),
                    Nickname = configuration.GetValue("DefaultUser:Nickname", ""),
                    Email = configuration.GetValue("DefaultUser:Email", ""),
                    EmailConfirmed = true,
                    Uid = 587538818672885760,
                    Avatar = "/files/avatars/201906/587538818672885760.jpg",
                };

                var result = userManager.CreateAsync(user, configuration.GetValue("DefaultUser:Password", "")).Result;

                if (result.Succeeded)
                {
                    userManager.AddClaimAsync(user, new Claim("is4-rights", "manager")).Wait();
                    userManager.AddClaimAsync(user, new Claim("username", configuration.GetValue("DefaultUser:UserName", ""))).Wait();
                    userManager.AddClaimAsync(user, new Claim("email", configuration.GetValue("DefaultUser:Email", ""))).Wait();
                    userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }

        private static void EnsureSeedIDS4Data(IDS4DbContext context, IServiceProvider sp)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in Configuration.GetClients())
                {
                    var entity = client.ToEntity();
                    context.Clients.Add(entity);
                }

                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                var identityResources = Configuration.GetIdentityResources().ToList();

                foreach (var resource in identityResources)
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Configuration.GetApiResources().ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }
        }
    }
}
