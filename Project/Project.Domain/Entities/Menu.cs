using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Menu : Entity <int>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The AuthorId field is required.")]
        public string AuthorId { get; set; } // Assuming you store the user ID as a string

        public List<Recipe> Recipes { get; set; } // Each Menu has a list of associated recipes

        public string ImageSrc { get; set; }


        public string RecipeOrder { get; set; }
    }
}
