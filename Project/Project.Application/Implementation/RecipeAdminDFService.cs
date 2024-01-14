using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Application.Abstraction;
using Project.Domain.Entities;
using Project.Infrastructure.Database;

namespace Project.Application.Implementation
{
    public class RecipeAdminDFService : IRecipeAdminDFService
    {
        public IList<Recipe> Select()
        {
            return DatabaseFake.Recipes;
        }

        public int Create(Recipe recipe)
        {
            if (DatabaseFake.Recipes != null && DatabaseFake.Recipes.Count > 0)
            {
                recipe.Id = DatabaseFake.Recipes.Last().Id + 1;
            }
            else
            {
                recipe.Id = 1;
            }

            if (DatabaseFake.Recipes != null)
            {
                DatabaseFake.Recipes.Add(recipe);
            }

            return recipe.Id; // Return the ID of the created recipe
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Recipe? recipe =
                DatabaseFake.Recipes.FirstOrDefault(r => r.Id == id);

            if (recipe != null)
            {
                deleted = DatabaseFake.Recipes.Remove(recipe);
            }

            return deleted;
        }

        public void AssociateRecipeWithCategories(int recipeId, int[] categoryIds)
        {
            Recipe recipe = DatabaseFake.Recipes.FirstOrDefault(r => r.Id == recipeId);

            if (recipe != null)
            {
                // Assign the selected category IDs to the recipe
                recipe.Categories = categoryIds;
            }
        }
        public void Edit(Recipe recipe)
        {
            // Find the existing recipe by ID
            Recipe existingRecipe = DatabaseFake.Recipes.FirstOrDefault(r => r.Id == recipe.Id);

            if (existingRecipe != null)
            {
                // Update the properties of the existing recipe
                existingRecipe.Name = recipe.Name;
                existingRecipe.Instructions = recipe.Instructions;
                existingRecipe.TimeForRecipe = recipe.TimeForRecipe;
                existingRecipe.Difficulty = recipe.Difficulty;
                existingRecipe.Price = recipe.Price;
                existingRecipe.Ingredients = recipe.Ingredients;
                // Update other properties as needed

                // Update the categories
                existingRecipe.Categories = recipe.Categories;

                // If you have a list of category IDs, you can update them as well
                //existingRecipe.Categories = recipe.CategoryIds.Select(id => new Category { Id = id }).ToList();
            }
        }



    }
}