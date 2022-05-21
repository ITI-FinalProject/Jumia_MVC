
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
        [MyAuthorize]
        public IActionResult Favorite()
        {
            var items = _favorite.GetFavoriteItems();
            _favorite.FavoriteItems = items;
            var response = new FavoriteVM()
            {
                Favorite = _favorite,
            };

            return View(response);
        }
        [MyAuthorize]
        public async Task<RedirectToActionResult> AddItemToFavorite(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);
            if (item != null)
            {
                _favorite.AddItemToFavorite(item);
                //item.in_favorites = true;
            }
            return RedirectToAction(nameof(Favorite));
        }

        public async Task<IActionResult> RemoveItemFromFavorite(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);
            if (item != null)
            {
                _favorite.RemoveItemFromFavorite(item);
                //item.in_favorites = false;
            }
            return RedirectToAction(nameof(Favorite));
        }
    }
}
