using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstraction;
using Project.Web.Models;
using System.Collections.Generic;
using Project.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Application.Implementation;

namespace Project.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeAdminService _recipeAdminService;
        private readonly IHomeService _homeService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecipeController(IRecipeAdminService recipeAdminService, IHomeService homeService, IHttpContextAccessor httpContextAccessor)
        {
            _recipeAdminService = recipeAdminService;
            _homeService = homeService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            IList<Recipe> recipes = _recipeAdminService.Select();
            return View("RecipeAdmin", recipes);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var categories = _homeService.GetHomeIndexViewModel().Categories;
            ViewBag.CategoryList = new MultiSelectList(categories, "Id", "Name");

            string currentUserName = _recipeAdminService.GetCurrentUserName(_httpContextAccessor.HttpContext);
            ViewBag.CurrentUserName = currentUserName;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                // Handle validation errors
                var categories = _homeService.GetHomeIndexViewModel().Categories;
                ViewBag.CategoryList = new MultiSelectList(categories, "Id", "Name");
                return View(recipe);
            }
            
            // Model is valid, proceed with creating the recipe

            // Ensure Categories is not null or empty
            if (recipe.Categories != null && recipe.Categories.Length > 0)
            {
                int recipeId = _recipeAdminService.Create(recipe);

                // ... other logic ...
                _recipeAdminService.AssociateRecipeWithCategories(recipeId, recipe.Categories);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Handle the case where no categories are selected
                ModelState.AddModelError("Categories", "At least one category must be selected.");
                var categories = _homeService.GetHomeIndexViewModel().Categories;
                ViewBag.CategoryList = new MultiSelectList(categories, "Id", "Name");
                return View(recipe);
            }
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _recipeAdminService.Delete(id);

            if (deleted)
            {
                // Redirect to the UserProfile view after successful deletion
                return RedirectToAction("UserProfile", "Profile"); // Replace "ControllerName" with the actual controller name for UserProfile
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Recipe(int recipeId)
        {
            Recipe recipe = GetRecipeById(recipeId);
            if (recipe == null)
            {
                return NotFound();
            }

            // Retrieve the selected categories for this recipe
            IList<Category> selectedCategories = GetSelectedCategories(recipeId);

            ViewData["SelectedCategories"] = selectedCategories;

            return View(recipe);
        }

        private IList<Category> GetSelectedCategories(int recipeId)
        {
            Recipe recipe = GetRecipeById(recipeId);

            if (recipe != null)
            {
                // Get all categories from the HomeService
                IList<Category> allCategories = _homeService.GetHomeIndexViewModel().Categories;

                // Filter the categories based on the recipe's category IDs
                IList<Category> selectedCategories = allCategories
                    .Where(category => recipe.Categories.Contains(category.Id))
                    .ToList();

                return selectedCategories;
            }

            return new List<Category>();
        }

        private Recipe GetRecipeById(int recipeId)
        {
            IList<Recipe> allRecipes = _recipeAdminService.Select();
            Recipe recipe = allRecipes.FirstOrDefault(r => r.Id == recipeId);
            return recipe;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Recipe recipe = GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            var categories = _homeService.GetHomeIndexViewModel().Categories;
            ViewBag.CategoryList = new MultiSelectList(categories, "Id", "Name", recipe.Categories);
            return View("Edit", recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe, int[] selectedCategoryIds)
        {
            _recipeAdminService.Edit(recipe);

            if (selectedCategoryIds != null)
            {
                _recipeAdminService.AssociateRecipeWithCategories(recipe.Id, selectedCategoryIds);
            }

            // Redirect to the Recipe action with the edited recipe's ID
            return RedirectToAction("Recipe", new { recipeId = recipe.Id });
        }

        [HttpGet]
        public IActionResult Search(string searchTerm, int? categoryId)
        {
            // Implement the logic to search for tips based on the searchTerm and categoryId
            IList<Recipe> searchResults = _recipeAdminService.SearchRecipes(searchTerm, categoryId);

            // Pass the search results to the view
            return View("SearchResultsRecipe", searchResults);
        }

        public IActionResult Details(int recipeId)
        {
            Recipe recipe = GetRecipeById(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            return View("Recipe", recipe);
        }


       
    }
}