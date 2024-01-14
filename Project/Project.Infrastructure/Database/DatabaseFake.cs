using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<Recipe> Recipes{ get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Tip> Tips { get; set; }

        static DatabaseFake()
        {
            DatabaseInit databaseInit = new DatabaseInit();
            Recipes = databaseInit.GetRecipes().ToList();
            Categories = databaseInit.GetCategories().ToList();
            Tips = databaseInit.GetTips().ToList();

        }
    }
}
