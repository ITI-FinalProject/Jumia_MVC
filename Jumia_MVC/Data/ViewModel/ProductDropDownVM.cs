using Jumia_MVC.Models;

namespace FinalProject.MVC.Data.ViewModel
{
    public class ProductDropDownVM
    {
       public  List<Category> Categories { get; set; }

        public ProductDropDownVM()
        {
            Categories=new List<Category>();   
        }
        // error
        //public static implicit operator ProductDropDownVM(ProductDropDownVM v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
