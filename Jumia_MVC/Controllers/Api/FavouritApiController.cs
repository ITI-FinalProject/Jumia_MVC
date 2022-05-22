using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jumia_MVC.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritApiController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly FavoriteProduct _favorite;
        public FavouritApiController(IProductsService productsService, FavoriteProduct favorite)
        {
            _productsService = productsService;
            _favorite = favorite;
        }
        [HttpGet]
        public IActionResult Favorite()
        {
            var items = _favorite.GetFavoriteItems();
            _favorite.FavoriteItems = items;
            var response = new FavoriteVM()
            {
                Favorite = _favorite,
            };

            return Ok(response);
        }
        [HttpPut("{id}")]
        // [Authorize(Roles = "User")]
        [MyAuthorize]
        public async Task<IActionResult> AddItemToFavorite(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);
            if (item != null)
            {
                _favorite.AddItemToFavorite(item);
                //item.in_favorites = true;
            }
            return Ok(item);
        }
        [HttpDelete("{id}")]
        // [Authorize(Roles = "User")]
        [MyAuthorize]
        public async Task<IActionResult> RemoveItemFromFavorite(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);
            if (item != null)
            {
                _favorite.RemoveItemFromFavorite(item);
                //item.in_favorites = false;
            }
            return Ok();
        }
    }

}
