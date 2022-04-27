using System.ComponentModel.DataAnnotations.Schema;

namespace Jumia_MVC.Models
{
    public class Colors
    {
        public int Id { get; set; }
        public string Color { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
