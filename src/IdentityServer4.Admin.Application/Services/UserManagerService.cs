using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.User;
using IdentityServer4.Admin.Domain.Commands.User;
using IdentityServer4.Admin.Domain.Core.Bus;
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
        private readonly IMediatorHandler _bus;
        public UserManagerService(UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IMediatorHandler bus)
        {
            _bus = bus;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateUserViewModel user)
        {
            var command = _mapper.Map<CreateUserCommand>(user);
            await _bus.SendCommand(command);
        }

        public Task DeleteAsync(Guid userId)
        {
            var command = new DeleteUserCommand(userId);
            return _bus.SendCommand(command);
        }

        public Task<int> GetTotalUsersAsync()
        {
            return _userManager.Users.CountAsync();
        }

        public async Task<PagingDataViewModel<PagingUserViewModel>> GetUsersAsync(PagingQueryViewModel vm)
        {
            int total;
            IEnumerable<ApplicationUser> users;
            if (string.IsNullOrEmpty(vm.Search))
            {
                users = await _userManager.Users.Skip(vm.Skip).Take(vm.PageSize).ToListAsync();
                total = await _userManager.Users.CountAsync();
            }
            else
            {
                var filter = UserFilter(vm.Search);
                total = await _userManager.Users.CountAsync(filter);

                users = await _userManager.Users.Where(filter).Skip(vm.Skip)
                    .Take(vm.PageSize)
                    .ToListAsync();
            }

            var data = _mapper.Map<IEnumerable<PagingUserViewModel>>(users);
            return new PagingDataViewModel<PagingUserViewModel>
            {
                Data = data,
                Total = total
            };
        }

        private Expression<Func<ApplicationUser, bool>> UserFilter(string search) =>
            u => u.UserName.Contains(search) ||
                    u.Nickname.Contains(search) ||
                    u.Email.Contains(search);
    }
}
