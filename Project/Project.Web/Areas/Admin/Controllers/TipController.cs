// TipAdminController.cs
using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstraction;
using Project.Domain.Entities;
using Project.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Project.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Http;

namespace Project.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class TipAdminController : Controller
    {
        private readonly ITipService _tipService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TipAdminController(ITipService tipService, IHttpContextAccessor httpContextAccessor)
        {
            _tipService = tipService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            IList<Tip> tips = _tipService.Select();
            return View("TipAdmin", tips);
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

            return RedirectToAction(nameof(TipAdminController.Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateTip");
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

            return View("CreateTip", tipViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _tipService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(TipAdminController.Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
