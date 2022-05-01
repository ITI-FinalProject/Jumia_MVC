
using FinalProject.MVC.Data.ViewModel;
using Jumia_MVC.Data.Base;
using Jumia_MVC.Models;

namespace Jumia_MVC.Data.services
{
    public interface IProductsService :IEntityBaseRepository<Product>
    {
        Task<ProductDropDownVM> GetProductDropDownVM();
        Task AddProductAsync(ProductVM entity);
        public Task<Product> GetProductByIdAsync(int id);
        Task UpdatedProductAsync(ProductVM entity);
      //  Task DeleteProductAsync(ProductVM entity);





    }
}
