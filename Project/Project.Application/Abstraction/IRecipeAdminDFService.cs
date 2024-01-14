using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Application.Abstraction
{
    public interface IRecipeAdminDFService
    {
        IList<Recipe> Select();
        int Create(Recipe recipe);
        bool Delete(int id);
        void AssociateRecipeWithCategories(int recipeId, int[] categoryIds);
        void Edit(Recipe updatedRecipe);
    }
}
