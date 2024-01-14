using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }
        public string ImageSrc { get; set; }

        public ICollection<Recipe> Recipes { get; set; }

    }
}
