using Jumia_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Jumia_MVC.Data.Favorite
{
    public class FavoriteProduct
    {
        public ApplicationDBContext _context { get; set; }
        public string FavoriteId { get; set; }
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

            return new FavoriteProduct(context) { FavoriteId = favoriteId };
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
                    Amount = 1
                };
                _context.FavoriteItems.Add(favoriteItem);
            }
            else
            {
                favoriteItem.Amount++;
            }
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
            _context.SaveChanges();
        }

        public List<FavoriteItem> GetFavoriteItems()
        {
            return FavoriteItems ?? (FavoriteItems = _context.FavoriteItems.Where(n => n.FavoriteId == FavoriteId).Include(n => n.Product).ToList());
        }

        public double GetFavoriteTotal()
        {
            var total = _context.FavoriteItems.Where(n => n.FavoriteId == FavoriteId).Select(n => n.Product.Price * n.Amount).Sum();
            return total;
        }
    }
}
