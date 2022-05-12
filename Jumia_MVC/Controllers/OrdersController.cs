

using Microsoft.AspNet.Identity;
using Stripe;
using System.IO;

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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var order = await _ordersService.GetOrderByUserIdAndRoleAsync(userId, userRole);
            return View(order);

        }


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
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessingAsync(string stripeToken,string stripeEmail)
        {

            var optionCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = User.Identity.Name,
                
            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionCust);
            var optionsCharge = new ChargeCreateOptions
            {
                Amount = (long?)_shoppingCart.GetShoppingCartTotal(),
                Currency = "USD",
                Description = "Buying Products",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,
            };
            var serviceCharge = new ChargeService();
            Charge charge = serviceCharge.Create(optionsCharge);
            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount);
                ViewBag.BalanceTxId = BalanceTransactionId;
                ViewBag.Customer = customer.Name;


                var items = _shoppingCart.GetShoppingCartItems();

                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string userEmailAdddress = User.FindFirstValue(ClaimTypes.Email);


                await _ordersService.StoreOrderAsync(items, userId, userEmailAdddress);
                await _shoppingCart.ClearShoppingCartAsync();
            }


            return View();
        }


        [MyAuthorize]
        public  async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction("Index", "Home");
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

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAdddress = User.FindFirstValue(ClaimTypes.Email);


            await _ordersService.StoreOrderAsync(items, userId, userEmailAdddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");

        }
    }
}
