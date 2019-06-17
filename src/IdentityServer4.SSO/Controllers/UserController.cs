using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Admin.BuildingBlock.Drawing;
using IdentityServer4.Admin.Identity.Entities;
using IdentityServer4.SSO.Models.User;
using IdGen;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.SSO.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IIdGenerator<long> _id;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RandomDrawing _drawing;
        public UserController(UserManager<ApplicationUser> userManager,
            RandomDrawing drawing,
            IIdGenerator<long> id)
        {
            _userManager = userManager;
            _drawing = drawing;
            _id = id;
        }

        public async Task<IActionResult> Profile()
        {
            var vm = await BuildProfileViewModel();
            if (vm == null)
            {
                return Unauthorized();
            }
            return View(vm);
        }

        public IActionResult Logs()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Avatar()
        {
            var image = _drawing.Generate(200, 200);
            image.Seek(0, System.IO.SeekOrigin.Begin);
            var id = _id.CreateId();
            return File(image, "image/jpeg", $"{id}.jpeg");
        }

        private async Task<ProfileViewModel> BuildProfileViewModel()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                return new ProfileViewModel
                {
                    Avatar = user.Avatar,
                    Nickname = user.Nickname,
                    UserName = user.UserName,
                    Email = user.Email
                };
            }
            return null;
        }
    }
}