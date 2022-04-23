using FinalProject.MVC.Data.services.Products;
using FinalProject.MVC.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jumia_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public async Task<IActionResult> Index()
        {

            var res=await _productsService.GellAll(e=>e.Category);
            if (res == null) return View("NotFound");

            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var movieDropData = await _productsService.GetProductDropDownVM();
            ViewBag.Category = new SelectList(movieDropData.Categories, "Id", "Name");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVM product)
        {
            if (!ModelState.IsValid)
            {

                var movieDropData = await _productsService.GetProductDropDownVM();
                ViewBag.Category = new SelectList(movieDropData.Categories, "Id", "Name");
                return View(product);
            }
            await _productsService.AddProductAsync(product);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return View("NotFound");
           var res=await _productsService.GetProductByIdAsync(id);
            if(res==null) return View("NotFound");
            return View(res);
        }

    }
}
