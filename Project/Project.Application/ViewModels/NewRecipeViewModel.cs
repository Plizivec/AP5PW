using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.ViewModels
{
    public class NewRecipeViewModel
    {
        public string Name { get; set; }
        public int TimeForRecipe { get; set; }
        public string Difficulty { get; set; }
        public int Price { get; set; }
        public string Ingredients { get; set; }
        public int[] Categories { get; set; }
        public string Instructions { get; set; }
        public string ImageSrc { get; set; }
    }
}
