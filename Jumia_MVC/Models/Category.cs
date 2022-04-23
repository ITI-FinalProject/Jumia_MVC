using Jumia_MVC.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia_MVC.Models
{
    public class Category : IEntityBase
    {
        public Category()
        {
           // products = new HashSet<Product>();
        }
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Name is Requried")]
        [Display(Name ="Name Category")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Image is Requried")]
        [Display(Name = "Image Category")]

        public string Image { get; set; }

       // public IEnumerable<Product> products { get; set; }
    }
}
