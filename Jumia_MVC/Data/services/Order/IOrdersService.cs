using Jumia_MVC.Models;

namespace Jumia_MVC.Data.services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
        Task<List<Order>> GetOrderByUserIdAndRoleAsync(string UserId, string userRole);

    }
}
