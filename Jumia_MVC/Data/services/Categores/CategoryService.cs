using Jumia_MVC.Data;
using Jumia_MVC.Data.Base;
using Jumia_MVC.Models;

namespace Jumia_MVC.Data.services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {

        public CategoryService(ApplicationDBContext context) : base(context) { }
    }
}
