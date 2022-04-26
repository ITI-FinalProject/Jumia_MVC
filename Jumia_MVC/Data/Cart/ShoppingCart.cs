using Jumia_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Jumia_MVC.Data.Cart
{
    public class ShoppingCart
    {


        public ApplicationDBContext _context { get; set; }

        public  string  ShoppingCartId{ get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        //ctor
        public ShoppingCart(ApplicationDBContext context)
        {
            _context = context;
        }

        //GetCart 
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDBContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        //add to cart
        public void AddItemToCart(Product product)
        {
            var ShoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id &&
            n.ShoppingCartId == ShoppingCartId);
            if(ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(ShoppingCartItem);
            }
            else
            {
                ShoppingCartItem.Amount ++;
            }
            _context.SaveChanges();

        }

        // remove from cart
        public void RemoveItemFromCart(Product product)
        {
            var ShoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id &&
                     n.ShoppingCartId == ShoppingCartId);
            if (ShoppingCartItem != null)
            {
                if (ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(ShoppingCartItem);
                }

            }
                _context.SaveChanges();

        }

        //get from cart
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId ==
            ShoppingCartId).Include(n => n.Product).ToList());


           
        }
        // total price
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(n=>n.ShoppingCartId == 
            ShoppingCartId).Select(n=>n.Product.Price *n.Amount).Sum();
            return total;
        }
        //Clear
        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
                      .ToListAsync();

            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();

        }
    }
}
