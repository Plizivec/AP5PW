using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Project.Domain.Entities;

namespace Project.Application.Abstraction
{
    public interface IRecipeAdminService
    {
        IList<Recipe> Select();
        int Create(Recipe recipe);
        bool Delete(int id);
        void AssociateRecipeWithCategories(int recipeId, int[] categoryIds);
        void Edit(Recipe updatedRecipe);
        IList<Recipe> SearchTips(string searchTerm);
        public IList<Recipe> SearchRecipes(string searchTerm, int? categoryId);
        string GetCurrentUserName(HttpContext context);
        IList<Recipe> GetRecipesByAuthor(string author);

        IList<Recipe> FilterRecipes(string searchTerm, string difficulty, string price, int? categoryId, int? timeForRecipe);
    }

}

