using FinalProject.MVC.Data.services.Products;
using Jumia_MVC.Data.Cart;
using Jumia_MVC.Data.services;
using Jumia_MVC.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Jumia_MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;


        //ctor
        public OrdersController(IProductsService productsService, ShoppingCart shoppingCart, IOrdersService orderService)
        {
                _productsService = productsService;
            _shoppingCart = shoppingCart;
            _ordersService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            string userId = "";
         

            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);

        }
        public IActionResult ShoppingCart()
        {
            var item = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = item;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };
            return View(response);
        }

        public  async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        } 
        //remove items

        public  async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        // Complet Order
        public async Task<IActionResult> CompletOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            string UserId = "" ;
            string userEmailAddress = "";


            await _ordersService.StoreOrderAsync(items, UserId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");

        }
    }
}
