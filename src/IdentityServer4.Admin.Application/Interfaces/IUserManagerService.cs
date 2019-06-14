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
        /// <summary>
        /// get users
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        Task<PagingDataViewModel<PagingUserViewModel>> GetUsersAsync(PagingQueryViewModel vm);
        /// <summary>
        /// Create a new user account
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateAsync(CreateUserViewModel user);
    }
}
