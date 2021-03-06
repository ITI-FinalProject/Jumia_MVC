using Jumia_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Jumia_MVC.Data.Favorite
{
    public class FavoriteProduct
    {
        public ApplicationDBContext _context { get; set; }
        public string FavoriteId { get; set; }
        public string userCartId { get; set; }

        public List<FavoriteItem> FavoriteItems { get; set; }
        public FavoriteProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        public static FavoriteProduct GetFavoriteProduct(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDBContext>();

            string favoriteId = session.GetString("FavoriteId") ?? Guid.NewGuid().ToString();
            session.SetString("FavoriteId", favoriteId);
            string userId = session.GetString("USERID") ?? Guid.NewGuid().ToString();


            return new FavoriteProduct(context) { FavoriteId = favoriteId, userCartId = userId };
        }

        public void AddItemToFavorite(Product product)
        {
            var favoriteItem = _context.FavoriteItems.FirstOrDefault(n => n.Product.Id == product.Id && n.FavoriteId == FavoriteId);

            if (favoriteItem == null)
            {
                favoriteItem = new FavoriteItem()
                {
                    FavoriteId = FavoriteId,
                    Product = product,
                    UserId = userCartId,
                    Amount = 1
                };
                _context.FavoriteItems.Add(favoriteItem);
                
            }
            else
            {
               // favoriteItem.Amount++;
            }
            product.in_favorites = true;
            _context.SaveChanges();
        }

        public void RemoveItemFromFavorite(Product product)
        {
            var favoriteItem = _context.FavoriteItems.FirstOrDefault(n => n.Product.Id == product.Id && n.FavoriteId == FavoriteId);

            if (favoriteItem != null)
            {
                if (favoriteItem.Amount > 1)
                {
                    favoriteItem.Amount--;
                }
                else
                {
                    _context.FavoriteItems.Remove(favoriteItem);
                }
            }
            product.in_favorites = false;
            _context.SaveChanges();
        }

        public List<FavoriteItem> GetFavoriteItems()
        {
            return FavoriteItems ?? (FavoriteItems = _context.FavoriteItems
                 .Where(n => n.FavoriteId == FavoriteId && n.UserId == userCartId).Include(n => n.Product).ToList());
        }

       
    }
}
