using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Domain.Entities;

namespace Project.Application.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; } // Add Id property

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }


        [Display(Name = "Image Source")]
        public string ImageSrc { get; set; }

        public string AuthorId { get; set; }
        


        // Add properties for Breakfast, Lunch, and Dinner
        public int BreakfastRecipeId1 { get; set; }
        public int LunchRecipeId1 { get; set; }
        public int DinnerRecipeId1 { get; set; }

        public int BreakfastRecipeId2 { get; set; }
        public int LunchRecipeId2 { get; set; }
        public int DinnerRecipeId2 { get; set; }

        public int BreakfastRecipeId3 { get; set; }
        public int LunchRecipeId3 { get; set; }
        public int DinnerRecipeId3 { get; set; }

        public int BreakfastRecipeId4 { get; set; }
        public int LunchRecipeId4 { get; set; }
        public int DinnerRecipeId4 { get; set; }

        public int BreakfastRecipeId5 { get; set; }
        public int LunchRecipeId5 { get; set; }
        public int DinnerRecipeId5 { get; set; }
    }
}
