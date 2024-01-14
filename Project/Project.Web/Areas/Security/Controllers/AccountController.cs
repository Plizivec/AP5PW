using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Application.ViewModels;
using Project.Web.Controllers;
using Project.Application.Abstraction;
using Project.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;

using Project.Web.Controllers;
using Project.Application.Implementation;

namespace Project.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {

        private readonly IAccountService accountService;
        private readonly IRecipeAdminService recipeAdminService;
        private readonly IMenuService menuService;
        private readonly ITipService tipService;

        // Use constructor injection to inject the required services
        public AccountController(
            IAccountService security,
            IRecipeAdminService recipeAdminService,
            IMenuService menuService,
            ITipService tipService)
        {
            this.accountService = security;
            this.recipeAdminService = recipeAdminService;
            this.menuService = menuService;
            this.tipService = tipService;
        }


       


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                string[] errors = await accountService.Register(registerVM, Roles.Customer);

                if (errors == null)
                {
                    LoginViewModel loginVM = new LoginViewModel()
                    {
                        Username = registerVM.Username,
                        Password = registerVM.Password
                    };

                    bool isLogged = await accountService.Login(loginVM);
                    if (isLogged)
                        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
                    else
                        return RedirectToAction(nameof(Login));
                }
                else
                {
                    //error to ViewModel
                }

            }

            return View(registerVM);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                bool isLogged = await accountService.Login(loginVM);
                if (isLogged)
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });

                loginVM.LoginFailed = true;
            }

            return View(loginVM);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();
            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        public IActionResult UserProfile()
        {
            var userName = User.Identity.Name;

            var recipes = recipeAdminService.GetRecipesByAuthor(userName);
            var menus = menuService.GetMenusByAuthor(userName);
            var tips = tipService.GetTipsByAuthor(userName);

            var viewModel = new UserProfileViewModel
            {
                UserName = userName,
                Recipes = recipes,
                Menus = menus,
                Tips = tips
            };

            return View(viewModel);
        }

    }
}