using IdentityServer4.AdminUI.Apis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Extensions
{
    public static class RefitExtensions
    {
        public static IHttpClientBuilder AddAdminApiHttpClient(this IHttpClientBuilder client, string baseUri)
        {
            return client.ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(baseUri);
            })
               .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
        }
    }
}
