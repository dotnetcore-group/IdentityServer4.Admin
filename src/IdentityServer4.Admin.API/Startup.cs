using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.Services;
using IdentityServer4.Admin.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.Admin.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Identity
            services.ConfigureIdentityDatabase(Configuration);
            
            // Auth
            services.AddIdentityServerAuth(Configuration);

            // Register Services
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }
            app.UseAuthentication();
            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);

            // SmartSql
            services.AddSmartSql(builder =>
            {
                builder.UseXmlConfig();
            })
                .AddRepositoryFromAssembly(options =>
                {
                    options.AssemblyString = "IdentityServer4.Admin.Domain";
                    options.Filter = type => type.FullName.EndsWith("Repository");
                });

        }
    }
}
