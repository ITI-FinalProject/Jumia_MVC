using FinalProject.MVC.Data.services;
using FinalProject.MVC.Data.services.Products;
using Jumia_MVC.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Diagnostics;
using System.Dynamic;

namespace Jumia_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService _productsService;
        private readonly IBannerService _bannerService;

        public HomeController(ILogger<HomeController> logger, IProductsService productsService, IBannerService bannerService)
        {
            _logger = logger;
            _productsService = productsService; 
            _bannerService = bannerService;
        }

        public async Task<IActionResult> Index()
        {
            dynamic mymodel = new ExpandoObject();
            ViewBag.banner = await _bannerService.GellAll();
            ViewBag.product =await _productsService.GellAll(e => e.Category);

            return View();
        }
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddMonths(3) });
            return LocalRedirect(returnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}