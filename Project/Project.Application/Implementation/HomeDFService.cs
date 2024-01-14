using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Abstraction;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Infrastructure.Database;

namespace Project.Application.Implementation
{
    public class HomeDFService : IHomeService
    {


        public RecipeViewModel GetHomeIndexViewModel()
        {
            RecipeViewModel viewModel = new RecipeViewModel();
            viewModel.Categories = DatabaseFake.Categories;

            viewModel.Recipes = DatabaseFake.Recipes;
            viewModel.Tips = DatabaseFake.Tips;
            return viewModel;
        }
    }
}
