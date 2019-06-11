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
using System.Threading.Tasks;

namespace IdentityServer4.SSO.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrationAndSeedDataDB(this IWebHost webHost)
        {
            Task.WaitAll(
                webHost.MigrateDbContextAsync<IDS4DbContext>(EnsureSeedIDS4DataAsync),
                webHost.MigrateDbContextAsync<AppIdentityDbContext>(EnsureSeedIdentityDataAsync)
            );
            webHost.MigrateDbContext<EventStoreContext>(null);

            return webHost;
        }

        private static async Task EnsureSeedIdentityDataAsync(AppIdentityDbContext context, IServiceProvider sp)
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var userManager = sp.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = sp.GetRequiredService<RoleManager<ApplicationRole>>();

            // Create admin role
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                var role = new ApplicationRole { Name = "Administrator" };

                await roleManager.CreateAsync(role);

                // Create admin user
                if (await userManager.FindByNameAsync(configuration.GetValue("DefaultUser:UserName", "")) != null) return;

                var user = new ApplicationUser
                {
                    UserName = configuration.GetValue("DefaultUser:UserName", ""),
                    Nickname = configuration.GetValue("DefaultUser:Nickname", ""),
                    Email = configuration.GetValue("DefaultUser:Email", ""),
                    EmailConfirmed = true,
                    Uid = 587538818672885760,
                    Avatar = "/files/avatars/201906/587538818672885760.jpg",
                };

                var result = await userManager.CreateAsync(user, configuration.GetValue("DefaultUser:Password", ""));

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("is4-rights", "manager"));
                    await userManager.AddClaimAsync(user, new Claim("username", configuration.GetValue("DefaultUser:UserName", "")));
                    await userManager.AddClaimAsync(user, new Claim("email", configuration.GetValue("DefaultUser:Email", "")));
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }

        private static async Task EnsureSeedIDS4DataAsync(IDS4DbContext context, IServiceProvider sp)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in Configuration.GetClients())
                {
                    var entity = client.ToEntity();
                    await context.Clients.AddAsync(entity);
                }

                await context.SaveChangesAsync();
            }

            if (!context.IdentityResources.Any())
            {
                var identityResources = Configuration.GetIdentityResources().ToList();

                foreach (var resource in identityResources)
                {
                    await context.IdentityResources.AddAsync(resource.ToEntity());
                }

                await context.SaveChangesAsync();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Configuration.GetApiResources().ToList())
                {
                    await context.ApiResources.AddAsync(resource.ToEntity());
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
