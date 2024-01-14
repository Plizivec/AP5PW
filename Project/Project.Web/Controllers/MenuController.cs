using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstraction;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Implementation;
using Microsoft.AspNetCore.Http;

namespace Project.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IRecipeAdminService _recipeAdminService; // Assuming you have a RecipeService
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuController(IMenuService menuService, IRecipeAdminService recipeAdminService, IHttpContextAccessor httpContextAccessor)
        {
            _menuService = menuService;
            _recipeAdminService = recipeAdminService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            // Implement code to display existing menus
            IList<Menu> menus = _menuService.Select();
            return View("Menus", menus);
        }

        public IActionResult Details(int id)
        {
            // Retrieve the menu with the specified id from your service
            Menu menu = _menuService.GetMenuById(id);

            // Check if the menu is found
            if (menu == null)
            {
                // Handle the case where the menu is not found, for example, return a 404 page
                return NotFound();
            }

            // Return the Menu view with the retrieved menu
            return View("Menu", menu);
        }

        public IActionResult Create()
        {
            var recipes = _recipeAdminService.Select();
            ViewBag.Recipes = new SelectList(recipes, "Id", "Name");

            string currentUserName = _recipeAdminService.GetCurrentUserName(_httpContextAccessor.HttpContext);
            ViewBag.CurrentUserName = currentUserName;

            return View(new MenuViewModel());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var recipeOrder = string.Join(",", new List<int>
                {
                    menuViewModel.BreakfastRecipeId1, menuViewModel.LunchRecipeId1, menuViewModel.DinnerRecipeId1,
                    menuViewModel.BreakfastRecipeId2, menuViewModel.LunchRecipeId2, menuViewModel.DinnerRecipeId2,
                    menuViewModel.BreakfastRecipeId3, menuViewModel.LunchRecipeId3, menuViewModel.DinnerRecipeId3,
                    menuViewModel.BreakfastRecipeId4, menuViewModel.LunchRecipeId4, menuViewModel.DinnerRecipeId4,
                    menuViewModel.BreakfastRecipeId5, menuViewModel.LunchRecipeId5, menuViewModel.DinnerRecipeId5
                });

                var menu = new Menu
                {
                    Name = menuViewModel.Name,
                    Description = menuViewModel.Description,
                    AuthorId = _menuService.GetCurrentUserName(_httpContextAccessor.HttpContext),
                    // Map each recipe ID to a Recipe entity
                    Recipes = GetRecipesFromIds(menuViewModel),
                    ImageSrc = menuViewModel.ImageSrc,
                    RecipeOrder = recipeOrder
                };

                _menuService.Create(menu);

                return RedirectToAction("Index");
            }

            // If ModelState is not valid, return to the Create view with validation errors
            return View(menuViewModel);
        }

        private List<Recipe> GetRecipesFromIds(MenuViewModel menuViewModel)
        {
            var recipeIds = new List<int?>()
        {
            menuViewModel.BreakfastRecipeId1, menuViewModel.LunchRecipeId1, menuViewModel.DinnerRecipeId1,
            menuViewModel.BreakfastRecipeId2, menuViewModel.LunchRecipeId2, menuViewModel.DinnerRecipeId2,
            menuViewModel.BreakfastRecipeId3, menuViewModel.LunchRecipeId3, menuViewModel.DinnerRecipeId3,
            menuViewModel.BreakfastRecipeId4, menuViewModel.LunchRecipeId4, menuViewModel.DinnerRecipeId4,
            menuViewModel.BreakfastRecipeId5, menuViewModel.LunchRecipeId5, menuViewModel.DinnerRecipeId5
        };

            return recipeIds
                .Where(recipeId => recipeId.HasValue)
                .Select(recipeId => GetRecipeById(recipeId.Value))
                .ToList();
        }

        private Recipe GetRecipeById(int recipeId)
        {
            IList<Recipe> allRecipes = _recipeAdminService.Select();
            Recipe recipe = allRecipes.FirstOrDefault(r => r.Id == recipeId);
            return recipe;
        }

        public string GetRecipeName(int? recipeId)
        {
            if (recipeId.HasValue)
            {
                var recipe = _recipeAdminService.Select().FirstOrDefault(r => r.Id == recipeId);

                if (recipe != null)
                {
                    return recipe.Name;
                }
                else
                {
                    // Recipe with the specified ID was not found
                    return "Recipe Not Found";
                }
            }

            // Return a placeholder if recipe ID is null
            return "No Recipe Selected";
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

            return RedirectToAction(nameof(MenuController.Index));
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


    }
}