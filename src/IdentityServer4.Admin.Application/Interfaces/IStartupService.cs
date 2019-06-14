using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Domain.Core.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IStartupService
    {
        bool IsInitialized();
        Task<(bool result, List<DomainError> errors)> Initialize(StartupViewModel model);
    }
}
