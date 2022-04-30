﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jumia_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ApplicationDBContext _context;


        private IEnumerable<Product> FilterList;

        public ProductController(IProductsService productsService, ApplicationDBContext context)
        {
            _productsService = productsService;
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 0)
        {
            var movieDropData = await _productsService.GetProductDropDownVM();
            ViewBag.Category = new SelectList(movieDropData.Categories, "Id", "Name");

            FilterList = await _productsService.GellAll(e=>e.Category);
            if (FilterList == null) return View("NotFound");

            //pagination
            
            const int PageSize = 9;
            var count = FilterList.Count(); //this.dataSource.Count();

            var data = FilterList.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Page = page;

            return View(data);

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

        public IActionResult AddComment(int ProductId, int Rating, string Comment)
        {
            Comments cm = new Comments();
            cm.ProductId = ProductId;
            cm.Rating = Rating;
            cm.Comment = Comment;
            cm.Date = DateTime.Now;


            _context.Comments.Add(cm);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
