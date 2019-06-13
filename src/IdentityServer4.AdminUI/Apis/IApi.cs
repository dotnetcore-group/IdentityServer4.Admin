using Panda.DynamicWebApi;
using Panda.DynamicWebApi.Attributes;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Apis
{
    [Headers("Authorization: Bearer")]
    public interface IApi
    {
    }
}
