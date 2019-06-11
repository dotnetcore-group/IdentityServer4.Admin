using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.User;
using IdentityServer4.Admin.Domain.Core.ViewModels;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UserManagerService(UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<PagingDataViewModel<PagingUserViewModel>> GetUsersAsync(PagingQueryViewModel vm)
        {
            IEnumerable<ApplicationUser> users = null;
            var total = 0;
            if (string.IsNullOrEmpty(vm.Search))
            {
                users = await _userManager.Users.Skip(vm.Skip).Take(vm.PageSize).ToListAsync();
                total = await _userManager.Users.CountAsync();
            }
            else
            {
                var where = new Func<ApplicationUser, bool>(u => u.UserName.Contains(vm.Search) ||
                    u.Nickname.Contains(vm.Search) ||
                    u.Email.Contains(vm.Search));

                total = _userManager.Users.Count(where);

                users = _userManager.Users.Where(where).Skip(vm.Skip)
                    .Take(vm.PageSize);
            }

            var data = _mapper.Map<IEnumerable<PagingUserViewModel>>(users);
            return new PagingDataViewModel<PagingUserViewModel>
            {
                Data = data,
                Total = total
            };
        }
    }
}
