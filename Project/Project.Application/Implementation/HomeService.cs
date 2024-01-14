using Project.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Abstraction;
using Project.Application.ViewModels;
using Project.Infrastructure.Database;
using Project.Infrastructure.Database;

namespace Project.Application.Implementation
{
    public class HomeService : IHomeService
    {

        RecipeDbContext _recipeDbContext;
        public HomeService(RecipeDbContext eshopDbContext)
        {
            _recipeDbContext = eshopDbContext;
        }

        public RecipeViewModel GetHomeIndexViewModel()
        {
            RecipeViewModel viewModel = new RecipeViewModel();
            viewModel.Recipes = _recipeDbContext.Recipes.ToList();
            viewModel.Categories = _recipeDbContext.Categories.ToList();
            viewModel.Tips = _recipeDbContext.Tips.ToList();
            return viewModel;
        }
    }
}
   