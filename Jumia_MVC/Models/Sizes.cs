using System.ComponentModel.DataAnnotations.Schema;

namespace Jumia_MVC.Models
{
    public class Sizes
    {
        public int Id { get; set; }
        public string Size { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
