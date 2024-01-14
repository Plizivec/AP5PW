// MenuAdminController.cs

using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstraction;
using Project.Web.Models;
using System.Collections.Generic;
using Project.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Application.Implementation;
using Microsoft.AspNetCore.Authorization;
using Project.Infrastructure.Identity.Enums;
using Project.Application.ViewModels;
using Project.Web.Areas.Admin.Controllers;

namespace Project.Web.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class MenuAdminController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IRecipeAdminService _recipeAdminService; // Assuming you have a service for Recipe administration
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuAdminController(IMenuService menuService, IRecipeAdminService recipeAdminService, IHttpContextAccessor httpContextAccessor)
        {
            _menuService = menuService;
            _recipeAdminService = recipeAdminService;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            IList<Menu> menus = _menuService.GetMenus();
            return View("MenuAdmin", menus);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Menu menu = _menuService.GetMenuById(id);

            if (menu == null)
            {
                return NotFound();
            }

            var recipes = _recipeAdminService.Select(); // Get all recipes for dropdown
            ViewBag.Recipes = new SelectList(recipes, "Id", "Name");

            // Map the Menu entity to MenuViewModel
            MenuViewModel viewModel = new MenuViewModel
            {
                Id = menu.Id,
                Name = menu.Name,
                Description = menu.Description,
                ImageSrc = menu.ImageSrc,
                // Split RecipeOrder string into an array
                BreakfastRecipeId1 = GetRecipeIdFromOrder(menu.RecipeOrder, 0),
                LunchRecipeId1 = GetRecipeIdFromOrder(menu.RecipeOrder, 1),
                DinnerRecipeId1 = GetRecipeIdFromOrder(menu.RecipeOrder, 2),
                BreakfastRecipeId2 = GetRecipeIdFromOrder(menu.RecipeOrder, 3),
                LunchRecipeId2 = GetRecipeIdFromOrder(menu.RecipeOrder, 4),
                DinnerRecipeId2 = GetRecipeIdFromOrder(menu.RecipeOrder, 5),
                BreakfastRecipeId3 = GetRecipeIdFromOrder(menu.RecipeOrder, 6),
                LunchRecipeId3 = GetRecipeIdFromOrder(menu.RecipeOrder, 7),
                DinnerRecipeId3 = GetRecipeIdFromOrder(menu.RecipeOrder, 8),
                BreakfastRecipeId4 = GetRecipeIdFromOrder(menu.RecipeOrder, 9),
                LunchRecipeId4 = GetRecipeIdFromOrder(menu.RecipeOrder, 10),
                DinnerRecipeId4 = GetRecipeIdFromOrder(menu.RecipeOrder, 11),
                BreakfastRecipeId5 = GetRecipeIdFromOrder(menu.RecipeOrder, 12),
                LunchRecipeId5 = GetRecipeIdFromOrder(menu.RecipeOrder, 13),
                DinnerRecipeId5 = GetRecipeIdFromOrder(menu.RecipeOrder, 14)
                // Map other RecipeId properties as needed
            };

            ViewBag.RecipeList = new SelectList(recipes, "Id", "Name");

            string currentUserName = _recipeAdminService.GetCurrentUserName(_httpContextAccessor.HttpContext);
            ViewBag.CurrentUserName = currentUserName;

            return View("Edit", viewModel);
        }

        [HttpPost]
        public IActionResult Edit(MenuViewModel viewModel)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                // Handle validation errors
                var recipes = _recipeAdminService.Select(); // Get all recipes for dropdown
                ViewBag.RecipeList = new SelectList(recipes, "Id", "Name");
                return View("Edit", viewModel);
            }

            // Model is valid, proceed with updating the menu

            // Retrieve the existing menu entity from the service
            Menu existingMenu = _menuService.GetMenuById(viewModel.Id);

            if (existingMenu == null)
            {
                return NotFound(); // Handle case where the menu doesn't exist
            }

            // Map properties from viewModel to menu entity
            existingMenu.Name = viewModel.Name;
            existingMenu.Description = viewModel.Description;
            existingMenu.ImageSrc = viewModel.ImageSrc;

            // Update the RecipeOrder based on the selected recipe IDs
            existingMenu.RecipeOrder = $"{viewModel.BreakfastRecipeId1},{viewModel.LunchRecipeId1},{viewModel.DinnerRecipeId1}," +
                                       $"{viewModel.BreakfastRecipeId2},{viewModel.LunchRecipeId2},{viewModel.DinnerRecipeId2}," +
                                       $"{viewModel.BreakfastRecipeId3},{viewModel.LunchRecipeId3},{viewModel.DinnerRecipeId3}," +
                                       $"{viewModel.BreakfastRecipeId4},{viewModel.LunchRecipeId4},{viewModel.DinnerRecipeId4}," +
                                       $"{viewModel.BreakfastRecipeId5},{viewModel.LunchRecipeId5},{viewModel.DinnerRecipeId5}";

            // Assuming you have a method to update the menu
            _menuService.EditMenu(existingMenu);

            return RedirectToAction(nameof(MenuAdminController.Index));
        }

        private int GetRecipeIdFromOrder(string recipeOrder, int index)
        {
            // Split the RecipeOrder string into an array of recipe IDs
            var recipeIds = recipeOrder.Split(',').Select(int.Parse).ToArray();

            // Check if the index is within bounds
            if (index >= 0 && index < recipeIds.Length)
            {
                return recipeIds[index];
            }

            // Return a default value or handle the case where the index is out of bounds
            return 0; // You may want to return a different default value or handle this case differently
        }

        [HttpGet]
        public IActionResult Create()
        {
            var recipes = _recipeAdminService.Select(); // Get all recipes for dropdown
            ViewBag.RecipeList = new SelectList(recipes, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                // Handle validation errors
                var recipes = _recipeAdminService.Select(); // Get all recipes for dropdown
                ViewBag.RecipeList = new SelectList(recipes, "Id", "Name");
                return View(menu);
            }

            // Model is valid, proceed with creating the menu

            // Assuming you have a method to create the menu
            int menuId = _menuService.Create(menu);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _menuService.DeleteMenu(id);

            if (deleted)
            {
                // Assuming you want to redirect to the Index after successful deletion
                return RedirectToAction(nameof(MenuAdminController.Index));
            }
            else
            {
                // You might want to add a message to inform the user about the failure
                return View("MenuAdmin", _menuService.GetMenus());
            }
        }
    }
}