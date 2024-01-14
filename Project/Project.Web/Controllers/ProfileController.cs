using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstraction;
using Project.Application.ViewModels;
using Project.Domain.Entities;

namespace Project.Web.Controllers
{
    public class ProfileController : Controller
    {

        private readonly IAccountService accountService;
        private readonly IRecipeAdminService recipeAdminService;
        private readonly IMenuService menuService;
        private readonly ITipService tipService;

        // Use constructor injection to inject the required services
        public ProfileController(
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
        public IActionResult Index()
        {
            return View();
        }

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
