// TipController.cs
using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstraction;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Web.Areas.Admin.Controllers;

namespace Project.Web.Controllers
{
    public class TipController : Controller
    {
        private readonly ITipService _tipService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TipController(ITipService tipService, IHttpContextAccessor httpContextAccessor)
        {
            _tipService = tipService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            IList<Tip> tips = _tipService.Select();
            return View("Tips", tips);
        }

        public IActionResult Details(int id)
        {
            Tip tip = _tipService.GetTipById(id);

            if (tip == null)
            {
                return NotFound();
            }

            return View("Tip", tip);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipViewModel tipViewModel)
        {
            if (ModelState.IsValid)
            {
                var tip = new Tip
                {
                    Text = tipViewModel.Text,
                    Name = tipViewModel.Name,
                    ImageSrc = tipViewModel.ImageSrc,
                    AutorId = _tipService.GetCurrentUserName(_httpContextAccessor.HttpContext),
                    // Map other properties
                };

                _tipService.Create(tip);

                return RedirectToAction("Index");
            }

            return View(tipViewModel);
        }

        public IActionResult Search(string searchTerm)
        {
            // Implement the logic to search for tips based on the searchTerm
            IList<Tip> searchResults = _tipService.SearchTips(searchTerm);

            // Pass the search results to the view
            return View("SearchResults", searchResults);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Tip tip = _tipService.GetTipById(id);

            if (tip == null)
            {
                return NotFound();
            }

            TipViewModel viewModel = new TipViewModel
            {
                Id = tip.Id,
                Name = tip.Name,
                Text = tip.Text,
                ImageSrc = tip.ImageSrc,

            };

            return View("Edit", viewModel);
        }

        [HttpPost]
        public IActionResult Edit(TipViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", viewModel);
            }

            Tip tip = new Tip
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Text = viewModel.Text,
                ImageSrc = viewModel.ImageSrc,

            };

            _tipService.Edit(tip);

            return RedirectToAction("UserProfile", "Profile"); 
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _tipService.Delete(id);

            if (deleted)
            {
                return RedirectToAction("UserProfile", "Profile");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
