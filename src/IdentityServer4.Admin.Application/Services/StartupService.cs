using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Domain.Core.ViewModels;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Services
{
    public class StartupService : IStartupService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStartupRepository _startupRepository;
        public StartupService(IStartupRepository startupRepository,
            UserManager<ApplicationUser> userManager)
        {
            _startupRepository = startupRepository;
            _userManager = userManager;
        }

        public async Task<(bool result, List<DomainError> errors)> Initialize(StartupViewModel model)
        {
            var userResult = await InitializeAdminUser(model.DefaultUser);

            var result = userResult;
            return result;
        }

        public bool IsInitialized()
        {
            return _startupRepository.FirstOrDefault(s => true)?.Initialized ?? false;
        }

        private async Task<(bool result, List<DomainError> errors)> InitializeAdminUser(DefaultUser user)
        {
            var appUser = new ApplicationUser
            {
                UserName = user.UserName,
                Nickname = user.UserName,
                Email = user.Email,
                EmailConfirmed = true,
                Uid = 1
            };
            var createResult = await _userManager.CreateAsync(appUser, user.Password);
            var addRoleResult = await _userManager.AddToRoleAsync(appUser, "Administrator");

            var errors = new List<IdentityError>();
            errors.AddRange(createResult.Errors);
            errors.AddRange(addRoleResult.Errors);

            var result = createResult.Succeeded &&
                addRoleResult.Succeeded;

            return (result, errors?.Select(e => new DomainError { Code = e.Code, Description = e.Description }).ToList());
        }
    }
}
