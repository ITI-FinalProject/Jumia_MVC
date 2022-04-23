using Jumia_MVC.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia_MVC.Models
{
    public class Banner : IEntityBase
    {
        public int Id { get; set; }

         [Required(ErrorMessage ="Image is requried")]
        public string Image { get; set; }
        [MaxLength(50)]

        public string Title { get; set; }
        [MaxLength(150)]

        public string SubTitle { get; set; }
    }
}
