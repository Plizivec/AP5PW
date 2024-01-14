using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Application.Abstraction;
using Project.Domain.Entities;
using Project.Infrastructure.Database;
using Project.Infrastructure.Identity;

namespace Project.Application.Implementation
{
    public class TipService : ITipService
    {
        private readonly RecipeDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public TipService(RecipeDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IList<Tip> Select()
        {
            return _dbContext.Tips.ToList();
        }

        public int Create(Tip tip)
        {
            _dbContext.Tips.Add(tip);
            _dbContext.SaveChanges();

            return tip.Id; // Return the ID of the created tip
        }

        public bool Delete(int id)
        {
            Tip? tip = _dbContext.Tips.FirstOrDefault(t => t.Id == id);

            if (tip != null)
            {
                _dbContext.Tips.Remove(tip);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public Tip GetTipById(int id)
        {
            return _dbContext.Tips.FirstOrDefault(t => t.Id == id);
        }

        public void Edit(Tip tip)
        {
            Tip existingTip = _dbContext.Tips.FirstOrDefault(t => t.Id == tip.Id);

            if (existingTip != null)
            {
                existingTip.Text = tip.Text;
                existingTip.Name = tip.Name;
                existingTip.ImageSrc = tip.ImageSrc;

                _dbContext.SaveChanges();
            }
        }

        public string GetCurrentUserName(HttpContext context)
        {
            var user = context.User.Identity.Name;
            return user ?? "Anonym";
        }


        public IList<Tip> SearchTips(string searchTerm)
        {
            searchTerm = searchTerm.ToLowerInvariant(); // Convert search term to lowercase for case-insensitive search

            return _dbContext.Tips
                .Where(t => t.Name.ToLower().Contains(searchTerm) || t.Text.ToLower().Contains(searchTerm))
                .ToList();
        }

        public IList<Tip> GetTipsByAuthor(string author)
        {
            return _dbContext.Tips
                .Where(t => t.AutorId == author)
                .ToList();
        }
    }
}