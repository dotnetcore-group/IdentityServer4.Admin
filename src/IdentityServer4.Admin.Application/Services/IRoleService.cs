using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.Role;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        public RoleService(RoleManager<ApplicationRole> roleManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleViewModel>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<IEnumerable<RoleViewModel>>(roles);
        }
    }
}
