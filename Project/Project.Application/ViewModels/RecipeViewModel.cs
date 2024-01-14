using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Application.ViewModels
{
    public class RecipeViewModel
    {
        public IList<Category> Categories { get; set; }
        public IList<Recipe> Recipes { get; set; }
        public IList<Tip> Tips { get; set; }

       
    }

}
