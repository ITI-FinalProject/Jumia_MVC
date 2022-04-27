using System.ComponentModel.DataAnnotations;

namespace FinalProject.MVC.Data.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }

        public ProductVM()
        {
           // Images = new List<Images>();
        }
     //   public int Id { get; set; }
        [Required(ErrorMessage = "Name is Requried")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Price is Requried")]

        public double Price { get; set; }
        public double Old_Price { get; set; }
        public int Discount { get; set; }

        public int Quentity { get; set; }

        [Required(ErrorMessage = "Description is Requried")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image is Requried")]

        public string Image { get; set; }


      //  public List<Images> Images { get; set; }

      //  public bool in_favorites { get; set; }
        //public bool in_cart { get; set; }


        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        [Range(0, 5)]
        public int Rate { get; set; }
    }
}
