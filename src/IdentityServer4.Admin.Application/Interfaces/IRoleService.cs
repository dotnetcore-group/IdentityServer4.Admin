using IdentityServer4.Admin.Application.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleViewModel>> GetAllRolesAsync();
    }
}
