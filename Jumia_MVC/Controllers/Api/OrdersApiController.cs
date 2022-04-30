

using Newtonsoft.Json;

namespace Jumia_MVC.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;


        //ctor
        public OrdersApiController(IProductsService productsService, ShoppingCart shoppingCart, IOrdersService orderService)
        {
            _productsService = productsService;
            _shoppingCart = shoppingCart;
            _ordersService = orderService;
        }

        [HttpGet]
        [MyAuthorize]
        public IActionResult ShoppingCart()
        {
            var item = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = item;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            //var jsonn=JsonConvert.SerializeObject(response);
          //  return Json();
            return Ok(response);
        }

        [HttpPut("{id}")]
        [MyAuthorize]
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return Ok();
        }
    }
}
