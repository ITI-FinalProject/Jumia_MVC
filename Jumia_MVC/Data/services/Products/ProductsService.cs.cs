using FinalProject.MVC.Data.ViewModel;
using Jumia_MVC.Data;
using Jumia_MVC.Data.Base;
using Jumia_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.MVC.Data.services.Products
{
    public class ProductsService :EntityBaseRepository<Product>, IProductsService
    {
        private readonly ApplicationDBContext _context;
        public ProductsService(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddProductAsync(ProductVM entity)
        {
            var newProduct = new Product()
            {
                Discount = entity.Discount,
                Image = entity.Image,
                Name = entity.Name,
                Old_Price = entity.Price,
                Price = entity.Price,
                Description = entity.Description,
                Quentity = entity.Quentity,
                CategoryId = entity.CategoryId,

            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductDropDownVM> GetProductDropDownVM()
        {
            var res = new ProductDropDownVM()
            {
                Categories = await _context.Categorys.OrderBy(e => e.Name).ToListAsync(),
               
            };
            return res;
        }
       

       public async Task<Product>  GetProductByIdAsync(int id)
        {
            var res = await _context.Products.Include(e => e.Category).Include(x => x.Images).Include(s => s.Sizes).Include(c => c.Colors)
                                  .FirstOrDefaultAsync(e => e.Id == id);
            return res;
        }

        public async Task UpdatedProductAsync(ProductVM entity)
        {
            var dbproduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == entity.Id);

            if (dbproduct != null)
            {
                dbproduct.Quentity = entity.Quentity;
                dbproduct.Old_Price = entity.Old_Price;
                dbproduct.Price = entity.Price;
                dbproduct.CategoryId = entity.CategoryId;
                dbproduct.Description=entity.Description;
                dbproduct.Name=entity.Name;
                dbproduct.Discount=entity.Discount;
                dbproduct.Image = entity.Image;

                await _context.SaveChangesAsync();
                
            }

        }
    }
}
