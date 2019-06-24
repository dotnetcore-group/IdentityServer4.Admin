using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.IoC
{
    public interface IBootStrapper
    {
         void RegisterServices(IServiceCollection services);
    }
}
