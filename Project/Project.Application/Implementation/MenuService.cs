using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Application.Abstraction;
using Project.Domain.Entities;
using Project.Infrastructure.Database;
using Project.Infrastructure.Identity;

namespace Project.Application.Implementation
{
   public class MenuService : IMenuService
    {
        private readonly RecipeDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuService(RecipeDbContext dbContext, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<Menu> GetMenus()
        {
            return _dbContext.Menus.Include(m => m.Recipes).ToList();
        }

        public Menu GetMenuById(int id)
        {
            return _dbContext.Menus.Include(m => m.Recipes).FirstOrDefault(m => m.Id == id);
        }
        public IList<Menu> Select()
        {
            return _dbContext.Menus.ToList();
        }

        public int Create(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();

            return menu.Id; // Return the ID of the created menu
        }

        public void EditMenu(Menu menu)
        {
            Menu existingMenu = _dbContext.Menus.Include(m => m.Recipes).FirstOrDefault(m => m.Id == menu.Id);

            if (existingMenu != null)
            {
                existingMenu.Name = menu.Name;
                existingMenu.Description = menu.Description;
                existingMenu.ImageSrc = menu.ImageSrc;
                existingMenu.RecipeOrder = menu.RecipeOrder; // Assuming RecipeOrder is also editable

                // Update associated recipes
                UpdateAssociatedRecipes(existingMenu, menu.RecipeOrder);

                _dbContext.SaveChanges();
            }
        }

        private void UpdateAssociatedRecipes(Menu existingMenu, string recipeOrder)
        {
            // Get the list of recipe IDs from the updated RecipeOrder
            var recipeIds = recipeOrder.Split(',').Select(int.Parse).ToList();

            // Clear existing recipes
            existingMenu.Recipes.Clear();

            // Add new recipes based on the updated RecipeOrder
            foreach (var recipeId in recipeIds)
            {
                var recipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == recipeId);
                if (recipe != null)
                {
                    existingMenu.Recipes.Add(recipe);
                }
            }
        }

        public bool DeleteMenu(int id)
        {
            Menu? menu = _dbContext.Menus.Include(m => m.Recipes).FirstOrDefault(m => m.Id == id);

            if (menu != null)
            {
                foreach (var recipe in menu.Recipes)
                {
                    _dbContext.Recipes.Remove(recipe);
                }

                _dbContext.Menus.Remove(menu);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public string GetCurrentUserName(HttpContext context)
        {
            var user = context.User.Identity.Name;
            return user ?? "Anonym";
        }

        public IList<Menu> GetMenusByAuthor(string author)
        {
            return _dbContext.Menus
                .Where(m => m.AuthorId == author)
                .ToList();
        }
    }
}
