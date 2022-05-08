using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jumia_MVC.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartApiController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;


        //ctor
        public ShoppingCartApiController(IProductsService productsService, ShoppingCart shoppingCart, IOrdersService orderService)
        {
            _productsService = productsService;
            _shoppingCart = shoppingCart;
            _ordersService = orderService;
        }

        [HttpGet]
        public IActionResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            var res = items.Count();
            return Ok(res);
        }
    }
}
