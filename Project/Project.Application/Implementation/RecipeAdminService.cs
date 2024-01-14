// RecipeAdminDFService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Project.Application.Abstraction;
using Project.Domain.Entities;
using Project.Infrastructure.Database;
using Microsoft.AspNetCore.Http;

namespace Project.Application.Implementation
{
    public class RecipeAdminService : IRecipeAdminService
    {
        private readonly RecipeDbContext _dbContext;

        public RecipeAdminService(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Recipe> Select()
        {
            var recipes = _dbContext.Recipes.ToList();

            return recipes;
        }

        public int Create(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();

            return recipe.Id; // Return the ID of the created recipe
        }

        public bool Delete(int id)
        {
            Recipe? recipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == id);

            if (recipe != null)
            {
                _dbContext.Recipes.Remove(recipe);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public void AssociateRecipeWithCategories(int recipeId, int[] categoryIds)
        {
            Recipe recipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == recipeId);

            if (recipe != null)
            {
                // Update the Categories property with the selected category IDs
                recipe.Categories = categoryIds;

                _dbContext.SaveChanges();
            }
        }

        public void Edit(Recipe recipe)
        {
            Recipe existingRecipe = _dbContext.Recipes
                .FirstOrDefault(r => r.Id == recipe.Id);

            if (existingRecipe != null)
            {
                existingRecipe.Name = recipe.Name;
                existingRecipe.Instructions = recipe.Instructions;
                existingRecipe.TimeForRecipe = recipe.TimeForRecipe;
                existingRecipe.Difficulty = recipe.Difficulty;
                existingRecipe.Price = recipe.Price;
                existingRecipe.Ingredients = recipe.Ingredients;

                // Update the categories directly in the Recipe entity
                existingRecipe.Categories = recipe.Categories;

                _dbContext.SaveChanges();
            }
        }

        public IList<Recipe> SearchTips(string searchTerm)
        {
            searchTerm = searchTerm.ToLowerInvariant(); // Convert search term to lowercase for case-insensitive search

            return _dbContext.Recipes
                .Where(t => t.Name.ToLower().Contains(searchTerm) || t.Ingredients.ToLower().Contains(searchTerm))
                .ToList();
        }

        public IList<Recipe> SearchRecipes(string searchTerm, int? categoryId)
        {
            // Your logic to search for recipes based on searchTerm and categoryId
            // If categoryId is null, don't filter by category; otherwise, filter by categoryId

            // Example: Assuming you have a method to get all recipes
            IList<Recipe> allRecipes = Select(); // Use the Select method

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Implement search logic based on searchTerm
                allRecipes = allRecipes.Where(r => r.Name.Contains(searchTerm) || r.Instructions.Contains(searchTerm)).ToList();
            }

            if (categoryId.HasValue)
            {
                // Implement category filtering logic
                allRecipes = allRecipes.Where(r => r.Categories.Contains(categoryId.Value)).ToList();
            }

            return allRecipes;
        }

        public string GetCurrentUserName(HttpContext context)
        {
            var user = context.User.Identity.Name;
            return user ?? "Anonym";
        }

        public IList<Recipe> GetRecipesByAuthor(string author)
        {
            return _dbContext.Recipes
                .Where(r => r.Author == author)
                .ToList();
        }

        public IList<Recipe> FilterRecipes(string searchTerm, string difficulty, string price, int? categoryId, int? timeForRecipe)
        {
            var query = _dbContext.Recipes.AsQueryable();

            // Apply filters based on provided parameters
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r => r.Name.Contains(searchTerm) || r.Instructions.Contains(searchTerm) || r.Ingredients.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(difficulty))
            {
                query = query.Where(r => r.Difficulty == difficulty);
            }

            if (!string.IsNullOrEmpty(price))
            {
                int priceValue;
                if (int.TryParse(price, out priceValue))
                {
                    query = query.Where(r => r.Price == priceValue);
                }
            }
            if (timeForRecipe.HasValue)
            {
                query = query.Where(r => r.TimeForRecipe <= timeForRecipe.Value);
            }

            // You can add more filters if needed...

            return query.ToList();
        }
    }
}
