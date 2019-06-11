﻿using IdentityServer4.Admin.Application.ViewModels.IdentityResource;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IIdentityResourceService
    {
        Task<IEnumerable<IdentityResourceViewModel>> GetIdentityResourcesAsync();
    }
}
