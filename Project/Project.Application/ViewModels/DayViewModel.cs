using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Application.ViewModels
{
    public class DayViewModel
    {
        public string DayName { get; set; } // For example, "Day1"
        public List<SelectListItem> AvailableRecipes { get; set; }
        public int? BreakfastRecipeId { get; set; }
        public int? LunchRecipeId { get; set; }
        public int? DinnerRecipeId { get; set; }
    }
}

