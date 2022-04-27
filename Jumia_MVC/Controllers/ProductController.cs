using FinalProject.MVC.Data.services.Products;
using FinalProject.MVC.Data.ViewModel;
using Jumia_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;

namespace Jumia_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;

        private IEnumerable<Product> FilterList;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var movieDropData = await _productsService.GetProductDropDownVM();
            ViewBag.Category = new SelectList(movieDropData.Categories, "Id", "Name");

            FilterList = await _productsService.GellAll(e=>e.Category);
            if (FilterList == null) return View("NotFound");
            //pagination
            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(FilterList.ToPagedList(pageNumber, pageSize));

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
            ViewBag.product = await _productsService.GellAll(e => e.Category);
            if (id == null) return View("NotFound");
           var res=await _productsService.GetProductByIdAsync(id);
            if(res==null) return View("NotFound");
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _productsService.GetProductByIdAsync(id);
            if (res == null) return View("NotFound");
            var respone = new ProductVM()
            {
                Price = res.Price,
                Discount = res.Discount,
                Image = res.Image,
                Name = res.Name,
                Id = res.Id,
                Description = res.Description,
                Old_Price = res.Old_Price,
                Quentity = res.Quentity,

            };
            var movieDropData = await _productsService.GetProductDropDownVM();
            ViewBag.Category = new SelectList(movieDropData.Categories, "Id", "Name");
            return View(respone);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductVM productVM)
        {
            if (id != productVM.Id) return View("NotFound");

            if (ModelState.IsValid)
            {
                await _productsService.UpdatedProductAsync(productVM);
                return RedirectToAction(nameof(Index));
            }
            var movieDropData = await _productsService.GetProductDropDownVM();
            ViewBag.Category = new SelectList(movieDropData.Categories, "Id", "Name");
            return View(productVM);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return View("NotFound");

            }
            var res = await _productsService.GetProductByIdAsync(id);
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

            var res = await _productsService.GetProductByIdAsync(id);
            await _productsService.delete(res);
            return RedirectToAction(nameof(Index));

        }

        //Filter
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _productsService.GellAll(n => n.Category);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allProducts.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                //var filteredResultNew = allProducts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allProducts);
        }

        //Filter Products
        public async Task<IActionResult> FilterProducts( int CategoryId)
        {
            var allProducts = await _productsService.GellAll(p => p.Category);
            var movieDropData = await _productsService.GetProductDropDownVM();
            ViewBag.Category = new SelectList(movieDropData.Categories, "Id", "Name");
          

            if (CategoryId == null) return View("Index", allProducts);

       
            var submitFilter = allProducts.Where(e => e.CategoryId == CategoryId).ToList();
           // FilterList = allProducts.Where(a => a.Category.Id == CategoryId ).ToList();
            return View("Index", submitFilter);
        }


    }
}
