using Jumia_MVC.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia_MVC.Models
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Requried")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Price is Requried")]

        public double Price { get; set; }
        public double Old_Price { get; set; }
        public int Discount { get; set; }
        [Range(0, 5, ErrorMessage ="Rate must be between 0:5")]
        public int Rate { get; set; }

        public int Quentity { get; set; }

        [Required(ErrorMessage = "Description is Requried")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image is Requried")]

        public string Image { get; set; }


        public List<Images>? Images { get; set; }

        [DefaultValue(false)]
        public bool in_favorites { get; set; }
        [DefaultValue(false)]

        public bool in_cart { get; set; }


        [ForeignKey("Category")]

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual List<Sizes>? Sizes { get; set; }

        public virtual List<Colors>? Colors { get; set; }
    }
}
