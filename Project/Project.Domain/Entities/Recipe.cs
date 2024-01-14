using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Recipe : Entity<int>
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Instructions field is required.")]
        public string Instructions { get; set; }

        [Required(ErrorMessage = "The TimeForRecipe field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The TimeForRecipe field must be greater than 0.")]
        public int TimeForRecipe { get; set; }

        [Required(ErrorMessage = "The Difficulty field is required.")]
        public string Difficulty { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Price field must be greater than or equal to 0.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "The Ingredients field is required.")]
        public string Ingredients { get; set; }
        //public ICollection<Ingredience> Ingredience { get; set; }
        //public string StravPref { get; set; }
        public double Rating { get; set; }
        public int[] Categories { get; set; } = Array.Empty<int>();
        //public List<Category> CategoriesList { get; set; }
        // Navigation property

        public string ImageSrc { get; set; }



        [Required(ErrorMessage = "The Author field is required.")]
        public string Author { get; set; } 
    }
}
