using FinalProject.MVC.Data.services.Categores;
using Jumia_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jumia_MVC.Controllers
{
    //[Authorize(Roles = UserRole.Admin)]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _servicecategory;

        public CategoryController(ICategoryService servicecategory)
        {
            _servicecategory = servicecategory;
        }
        public async Task<IActionResult> Index()
        {
            var res=await _servicecategory.GellAll();
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _servicecategory.GetById(id);
            if (category == null) return View("NotFound");
            return View(category);

        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if(!ModelState.IsValid) return View(category);

            var res=new Category()
            {
                Name = category.Name,
                Image=category.Image,
            };
            await _servicecategory.Add(res);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var res = await _servicecategory.GetById(id);
            if (res == null) return View("NotFound");
            return View(res);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id) return View("NotFound");
            if (ModelState.IsValid)
            {
               await _servicecategory.update(category);
                return RedirectToAction(nameof(Index));

            }


            return View(category);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return View("NotFound");

            }
            var res = await _servicecategory.GetById(id);
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

            var res = await _servicecategory.GetById(id);
            await _servicecategory.delete(res);
            return RedirectToAction(nameof(Index));

        }






    }
}
