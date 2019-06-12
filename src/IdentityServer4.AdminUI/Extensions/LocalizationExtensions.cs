using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Extensions
{
    public static class LocalizationExtensions
    {
        public static void AddMvcLocalization(this IServiceCollection services)
        {
            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            services.Configure<RequestLocalizationOptions>(
                            opts =>
                            {
                                var supportedCultures = new[]
                                {
                                    new CultureInfo("zh-cn"),
                                    new CultureInfo("en-us"),
                                };

                                opts.DefaultRequestCulture = new RequestCulture("zh-cn");
                                opts.SupportedCultures = supportedCultures;
                                opts.SupportedUICultures = supportedCultures;
                            });
        }

        public static void UseLocalization(this IApplicationBuilder app)
        {
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
        }
    }
}
