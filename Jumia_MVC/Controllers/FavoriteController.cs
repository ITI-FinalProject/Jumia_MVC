
namespace Jumia_MVC.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly FavoriteProduct _favorite;
        public FavoriteController(IProductsService productsService, FavoriteProduct favorite)
        {
            _productsService = productsService;
            _favorite = favorite;
        }
        public IActionResult Favorite()
        {
            var items = _favorite.GetFavoriteItems();
            _favorite.FavoriteItems = items;
            var response = new FavoriteVM()
            {
                Favorite = _favorite,
                FavoriteTotal = _favorite.GetFavoriteTotal()
            };

            return View(response);
        }

        public async Task<RedirectToActionResult> AddItemToFavorite(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);
            if (item != null)
            {
                _favorite.AddItemToFavorite(item);
            }
            return RedirectToAction(nameof(Favorite));
        }

        public async Task<IActionResult> RemoveItemFromFavorite(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);
            if (item != null)
            {
                _favorite.RemoveItemFromFavorite(item);
            }
            return RedirectToAction(nameof(Favorite));
        }
    }
}
