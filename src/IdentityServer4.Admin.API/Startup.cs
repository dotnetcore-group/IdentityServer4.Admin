using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.API.Filters;
using IdentityServer4.Admin.IoC;
using IdentityServer4.Admin.IoC.AutofacInjector;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

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
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddMvc(options =>
            {
                options.Filters.Add<ModelStateValidationFilter>();
                options.Filters.Add<HttpGlobalExceptionFilter>();
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.ConfigureLocalization();

            // Identity
            services.ConfigureIdentityDatabase(Configuration);

            services.AddAuthorizationPolicies();

            // Auth
            services.AddIdentityServerAuth(Configuration);

            services.AddSwagger(Configuration);

            // Config automapper
            services.AddAutoMapperSetup();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // Register Services
            RegisterServices(services);

            //return AutofacInjectorBootstrapper.RegisterServices(services);
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

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "IdentityServer4 Admin API");
                c.OAuthClientId("Swagger");
                c.OAuthAppName("IdentityServer4 Admin API - full access");
            });

            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
