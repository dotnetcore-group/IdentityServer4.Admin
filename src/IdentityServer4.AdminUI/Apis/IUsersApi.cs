using IdentityServer4.Admin.Application.ViewModels.User;
using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Admin.Domain.Core.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Apis
{
    [Headers("Authorization: Bearer")]
    public interface IUsersApi
    {
        [Get("/users")]
        Task<JsonResponse<PagingDataViewModel<PagingUserViewModel>>> GetUsersAsync([Query]PagingQueryViewModel vm);
    }
}
