// RecipeAdminController.cs in the Admin area
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Application.Abstraction;
using Project.Application.Implementation;
using Project.Domain.Entities;
using Project.Infrastructure.Identity.Enums;
using System.Linq;

namespace Project.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class RecipeAdminController : Controller
    {
        private readonly IRecipeAdminService _recipeAdminService;
        private readonly IHomeService _homeService;

        public RecipeAdminController(IRecipeAdminService recipeAdminService, IHomeService homeService)
        {
            _recipeAdminService = recipeAdminService;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            IList<Recipe> recipes = _recipeAdminService.Select();
            return View("RecipeAdmin", recipes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // You can add any additional logic or view data here if needed
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            int recipeId = _recipeAdminService.Create(recipe);

            // You can add any additional logic or view data here if needed

            return RedirectToAction(nameof(RecipeAdminController.Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Recipe recipe = _recipeAdminService.Select().FirstOrDefault(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            var categories = _homeService.GetHomeIndexViewModel().Categories;
            ViewBag.CategoryList = new MultiSelectList(categories, "Id", "Name");
            // You can add any additional logic or view data here if needed

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            _recipeAdminService.Edit(recipe);

            // You can add any additional logic or view data here if needed

            return RedirectToAction(nameof(RecipeAdminController.Index));
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _recipeAdminService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(RecipeAdminController.Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
