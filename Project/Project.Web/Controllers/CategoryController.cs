using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstraction;
using Project.Web.Models;
using System.Collections.Generic;
using Project.Domain.Entities;

namespace Project.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly IRecipeAdminService _recipeAdminService;

        public CategoryController(IHomeService homeService, IRecipeAdminService recipeAdminService)
        {
            _homeService = homeService;
            _recipeAdminService = recipeAdminService;
        }

        public IActionResult Category(int categoryId, string difficulty = "", int? price = null)
        {
            Category selectedCategory = _homeService.GetHomeIndexViewModel().Categories.FirstOrDefault(c => c.Id == categoryId);

            if (selectedCategory == null)
            {
                return NotFound();
            }

            // Get recipes in the selected category and apply additional filters
            IList<Recipe> recipesInCategory = _recipeAdminService.Select()
                .Where(r => r.Categories.Contains(categoryId))
                .ToList();

            // Apply additional filters based on difficulty and price
            if (!string.IsNullOrEmpty(difficulty))
            {
                recipesInCategory = recipesInCategory.Where(r => r.Difficulty == difficulty).ToList();
            }

            if (price.HasValue)
            {
                recipesInCategory = recipesInCategory.Where(r => r.Price <= price.Value).ToList();
            }

            var tupleModel = new Tuple<Category, IList<Recipe>>(selectedCategory, recipesInCategory);

            return View(tupleModel);
        }

        private List<Recipe> GetRecipesByCategory(int categoryId)
        {
            // Get all recipes
            IList<Recipe> allRecipes = _recipeAdminService.Select();

            // Filter recipes by category
            List<Recipe> recipesInCategory = allRecipes
                .Where(recipe => recipe.Categories.Contains(categoryId))
                .ToList();

            return recipesInCategory;
        }

        public IActionResult AllRecipes()
        {
            // Get all recipes
            IList<Recipe> allRecipes = _recipeAdminService.Select();

            // Pass all recipes to the "Category" view
            return View("AllRecipes", allRecipes);
        }
        [HttpPost]
        public IActionResult FilterRecipes(int categoryId, string searchTerm, string difficulty, int? price, int? timeForRecipe)
        {
            // Get recipes in the selected category and apply additional filters
            IList<Recipe> recipesInCategory = _recipeAdminService.Select()
                .Where(r => r.Categories.Contains(categoryId))
                .ToList();
            
            // Apply additional filters based on difficulty and price
            if (!string.IsNullOrEmpty(difficulty))
            {
                recipesInCategory = recipesInCategory.Where(r => r.Difficulty == difficulty).ToList();
            }

            if (price.HasValue)
            {
                recipesInCategory = recipesInCategory.Where(r => r.Price <= price.Value).ToList();
            }

            if (timeForRecipe.HasValue)
            {
                recipesInCategory = recipesInCategory.Where(r => r.TimeForRecipe <= timeForRecipe.Value).ToList();
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                recipesInCategory = recipesInCategory
                    .Where(r => r.Name.ToLower().Contains(searchTerm))
                    .ToList();
            }

            var tupleModel = new Tuple<Category, IList<Recipe>>(_homeService.GetHomeIndexViewModel().Categories.FirstOrDefault(c => c.Id == categoryId), recipesInCategory);

            return View("FilteredCategory", tupleModel);
        }
    }
}