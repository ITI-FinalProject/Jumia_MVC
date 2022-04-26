using Jumia_MVC.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Jumia_MVC.Data.ViewComponant
{
    
    public class ShoppingCatSummary :ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCatSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
