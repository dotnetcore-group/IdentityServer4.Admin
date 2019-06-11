using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.User;
using IdentityServer4.Admin.Domain.Core.ViewModels;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IUserManagerService
    {
        Task<PagingDataViewModel<PagingUserViewModel>> GetUsersAsync(PagingQueryViewModel vm);
    }
}
