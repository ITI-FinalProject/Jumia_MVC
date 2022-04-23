using FinalProject.MVC.Data.services;
using Jumia_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jumia_MVC.Controllers
{

    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IActionResult> Index()
        {
            var res =await _bannerService.GellAll();
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _bannerService.GetById(id);
            if (category == null) return View("NotFound");
            return View(category);

        }
        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Banner banner)
        {
            if (!ModelState.IsValid) return View(banner);

            var res = new Banner()
            {
                Title = banner.Title,
                SubTitle = banner.SubTitle,
                Image = banner.Image,
            };
            await _bannerService.Add(res);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var res = await _bannerService.GetById(id);
            if (res == null) return View("NotFound");
            return View(res);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Banner banner)
        {
            if (id != banner.Id) return View("NotFound");
            if (ModelState.IsValid)
            {
               await _bannerService.update(banner);
                return RedirectToAction(nameof(Index));

            }


            return View(banner);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return View("NotFound");

            }
            var res = await _bannerService.GetById(id);
            if (res == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(res);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var res = await _bannerService.GetById(id);
           await _bannerService.delete(res);
            return RedirectToAction(nameof(Index));

        }
    }
}
