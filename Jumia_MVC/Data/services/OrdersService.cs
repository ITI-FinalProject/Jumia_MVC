using Jumia_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Jumia_MVC.Data.services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDBContext _context;

        public OrdersService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var order = await _context.Orders.Include(n => n.OrderItems).
                ThenInclude(n => n.Product).Where(n => n.UserId == userId).ToListAsync();
        
            return order;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var neworder = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
                
            };
            await _context.Orders.AddAsync(neworder);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    OrderId = neworder.Id,
                    Price = item.Product.Price

                };

                await _context.OrderItems.AddAsync(orderItem);

            }
            await _context.SaveChangesAsync();
        }
    }
}
